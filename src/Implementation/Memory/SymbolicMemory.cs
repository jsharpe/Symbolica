using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Symbolica.Abstraction;
using Symbolica.Collection;
using Symbolica.Expression;

namespace Symbolica.Implementation.Memory
{
    internal sealed class SymbolicMemory : IPersistentMemory
    {
        private readonly Bytes _alignment;
        private readonly IBlockFactory _blockFactory;
        private readonly IPersistentList<IPersistentBlock> _blocks;

        private SymbolicMemory(Bytes alignment, IBlockFactory blockFactory,
            IPersistentList<IPersistentBlock> blocks)
        {
            _alignment = alignment;
            _blockFactory = blockFactory;
            _blocks = blocks;
        }

        public (IExpression, IPersistentMemory) Allocate(ISpace space, Section section, Bits size)
        {
            var address = CreateAddress(space, size.ToBytes());
            var block = _blockFactory.Create(space, section, address, size);

            return (address, new SymbolicMemory(_alignment, _blockFactory,
                _blocks.Add(block)));
        }

        public (IExpression, IPersistentMemory) Move(ISpace space, Section section, IExpression address, Bits size)
        {
            foreach (var (block, index) in _blocks.Select((b, i) => (b, i)))
                if (block.CanFree(space, section, address))
                {
                    var newAddress = CreateAddress(space, size.ToBytes());
                    var newBlock = block.Move(newAddress, size);

                    return (newAddress, new SymbolicMemory(_alignment, _blockFactory,
                        _blocks.SetItem(index, newBlock)));
                }

            throw new StateException("Attempted to move invalid Memory.", space);
        }

        public IPersistentMemory Free(ISpace space, Section section, IExpression address)
        {
            foreach (var (block, index) in _blocks.Select((b, i) => (b, i)))
                if (block.CanFree(space, section, address))
                    return new SymbolicMemory(_alignment, _blockFactory,
                        _blocks.SetItem(index, _blockFactory.CreateInvalid()));

            throw new StateException("Attempted to free invalid Memory.", space);
        }

        public IPersistentMemory Write(ISpace space, IExpression address, IExpression value)
        {
            var newBlocks = new List<KeyValuePair<int, IPersistentBlock>>();

            foreach (var (block, index) in _blocks.Select((b, i) => (b, i)))
            {
                var result = block.TryWrite(space, address, value);

                if (!result.CanBeSuccess)
                    continue;

                newBlocks.Add(KeyValuePair.Create(index, result.Value));

                if (!result.CanBeFailure)
                    return new SymbolicMemory(_alignment, _blockFactory,
                        _blocks.SetItems(newBlocks));

                space = result.FailureSpace;
            }

            throw new StateException("Attempted to write to invalid Memory.", space);
        }

        public IExpression Read(ISpace space, IExpression address, Bits size)
        {
            var expression = space.CreateConstant(size, BigInteger.Zero);

            foreach (var block in _blocks)
            {
                var result = block.TryRead(space, address, size);

                if (!result.CanBeSuccess)
                    continue;

                expression = expression.Or(result.Value);

                if (!result.CanBeFailure)
                    return expression;

                space = result.FailureSpace;
            }

            throw new StateException("Attempted to read from invalid Memory.", space);
        }

        private IExpression CreateAddress(ISpace space, Bytes size)
        {
            return space.CreateSymbolic(space.PointerSize, null,
                _blocks
                    .Where(b => b.IsValid)
                    .Select(b => new Func<IExpression, IExpression>(a => IsFullyOutside(space, b, a, size)))
                    .Append(a => a
                        .NotEqual(space.CreateConstant(a.Size, BigInteger.Zero)))
                    .Append(a => a
                        .UnsignedLessOrEqual(GetBound(space, a, size)))
                    .Append(a => a
                        .UnsignedRemainder(space.CreateConstant(a.Size, (uint) _alignment))
                        .Equal(space.CreateConstant(a.Size, BigInteger.Zero))));
        }

        private static IExpression IsFullyOutside(ISpace space, IPersistentBlock block, IExpression address, Bytes size)
        {
            return GetBound(space, address, size).UnsignedLessOrEqual(block.Address)
                .Or(address.UnsignedGreaterOrEqual(GetBound(space, block.Address, block.Size)));
        }

        private static IExpression GetBound(ISpace space, IExpression address, Bytes size)
        {
            return address.Add(space.CreateConstant(address.Size, (uint) size));
        }

        public static IPersistentMemory Create(Bytes alignment,
            IBlockFactory blockFactory, ICollectionFactory collectionFactory)
        {
            return new SymbolicMemory(alignment, blockFactory,
                collectionFactory.CreatePersistentList<IPersistentBlock>());
        }
    }
}

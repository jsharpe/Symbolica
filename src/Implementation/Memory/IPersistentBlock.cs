﻿using Symbolica.Expression;

namespace Symbolica.Implementation.Memory
{
    internal interface IPersistentBlock
    {
        bool IsValid { get; }
        IExpression Address { get; }
        Bytes Size { get; }

        IPersistentBlock Move(IExpression address, Bits size);
        bool CanFree(ISpace space, Section section, IExpression address);
        Result<IPersistentBlock> TryWrite(ISpace space, IExpression address, IExpression value);
        Result<IExpression> TryRead(ISpace space, IExpression address, Bits size);
    }
}

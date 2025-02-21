﻿using Symbolica.Abstraction;

namespace Symbolica.Representation.Functions
{
    internal sealed class FunnelShiftLeft : IFunction
    {
        public FunnelShiftLeft(FunctionId id, IParameters parameters)
        {
            Id = id;
            Parameters = parameters;
        }

        public FunctionId Id { get; }
        public IParameters Parameters { get; }

        public void Call(IState state, ICaller caller, IArguments arguments)
        {
            var high = arguments.Get(0);
            var low = arguments.Get(1);
            var shift = arguments.Get(2);

            var size = state.Space.CreateConstant(shift.Size, (uint) shift.Size);
            var offset = shift.UnsignedRemainder(size);

            var result = high.ShiftLeft(offset)
                .Or(low.LogicalShiftRight(size.Subtract(offset)));

            state.Stack.SetVariable(caller.Id, result);
        }
    }
}

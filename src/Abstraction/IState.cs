﻿using System;
using Symbolica.Expression;

namespace Symbolica.Abstraction
{
    public interface IState
    {
        ISpace Space { get; }
        IMemory Memory { get; }
        IStack Stack { get; }
        ISystem System { get; }

        IFunction GetFunction(FunctionId id);
        IExpression GetGlobalAddress(GlobalId id);
        void Complete();
        void Fork(IExpression condition, Action<IState> trueAction, Action<IState> falseAction);
    }
}

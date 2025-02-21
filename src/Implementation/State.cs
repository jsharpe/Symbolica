﻿using System;
using Symbolica.Abstraction;
using Symbolica.Expression;
using Symbolica.Implementation.Memory;
using Symbolica.Implementation.Stack;
using Symbolica.Implementation.System;

namespace Symbolica.Implementation
{
    internal sealed class State : IState, IExecutableState
    {
        private readonly IMemoryProxy _memory;
        private readonly IModule _module;
        private readonly IProgramPool _programPool;
        private readonly IStackProxy _stack;
        private readonly ISystemProxy _system;
        private IPersistentGlobals _globals;
        private bool _isComplete;

        public State(IProgramPool programPool, IModule module, ISpace space,
            IPersistentGlobals globals, IMemoryProxy memory, IStackProxy stack, ISystemProxy system)
        {
            _isComplete = false;
            _programPool = programPool;
            _module = module;
            Space = space;
            _globals = globals;
            _memory = memory;
            _stack = stack;
            _system = system;
        }

        public bool TryExecuteNextInstruction()
        {
            if (_isComplete)
                return false;

            _stack.ExecuteNextInstruction(this);

            return true;
        }

        public ISpace Space { get; }
        public IMemory Memory => _memory;
        public IStack Stack => _stack;
        public ISystem System => _system;

        public IFunction GetFunction(FunctionId id)
        {
            return _module.GetFunction(id);
        }

        public IExpression GetGlobalAddress(GlobalId id)
        {
            var (address, action, globals) = _globals.GetAddress(_memory, id);
            _globals = globals;

            action(this);
            return address;
        }

        public void Complete()
        {
            _isComplete = true;
        }

        public void Fork(IExpression condition, Action<IState> trueAction, Action<IState> falseAction)
        {
            using var proposition = condition.GetProposition(Space);

            if (proposition.CanBeFalse)
            {
                if (proposition.CanBeTrue)
                {
                    Clone(proposition.FalseSpace, falseAction);
                    Clone(proposition.TrueSpace, trueAction);

                    Complete();
                }
                else
                {
                    falseAction(this);
                }
            }
            else
            {
                trueAction(this);
            }
        }

        private void Clone(ISpace space, Action<IState> action)
        {
            _programPool.Add(new Program(() => Create(space, action)));
        }

        private IExecutableState Create(ISpace space, Action<IState> action)
        {
            var memory = _memory.Clone(space);
            var stack = _stack.Clone(space, memory);
            var system = _system.Clone(space, memory);

            var state = new State(_programPool, _module, space,
                _globals, memory, stack, system);

            action(state);

            return state;
        }
    }
}

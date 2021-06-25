using System;
using System.Collections.Generic;
using System.Linq;
using Masya.RPNCalculator.Core.Abstractions;
using Masya.RPNCalculator.Core.Parsing;

namespace Masya.RPNCalculator.Core.Calculations
{
    public class DefaultCalculator : ICalculator
    {
        private readonly Stack<IOperationParticipant> _stack;
        private const int DefaultMaxStackSize = 256;

        public DefaultCalculator() : this(DefaultMaxStackSize) { }

        public DefaultCalculator(int maxStackSize)
        {
            _stack = new Stack<IOperationParticipant>(maxStackSize);
        }

        public double Calculate(ParsingResult<IOperationParticipant> result)
        {
            var reverseOutput = result.Output.Reverse();
            foreach (var participant in reverseOutput)
            {
                if (participant is Operand operand)
                {
                    _stack.Push(operand);
                }
                else if (participant is Operation operation)
                {
                    double operandLeft = ((Operand)_stack.Pop()).Value;
                    double operandRight = ((Operand)_stack.Pop()).Value;
                    _stack.Push(new Operand(operation.Function(operandLeft, operandRight)));
                }
            }

            if (_stack.Count > 1)
            {
                throw new InvalidOperationException("There are extra operands or operations in the parsing result.");
            }

            return ((Operand)_stack.Pop()).Value;
        }
    }
}
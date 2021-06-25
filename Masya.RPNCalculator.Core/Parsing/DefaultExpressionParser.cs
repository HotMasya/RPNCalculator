using System;
using System.Collections.Generic;
using Masya.RPNCalculator.Core.Abstractions;
using Masya.RPNCalculator.Core.Calculations;

namespace Masya.RPNCalculator.Core.Parsing
{
    public class DefaultExpressionParser : IExpressionParser
    {
        private readonly Stack<Operation> _stack;
        private const int DefaultMaxStackSize = 256;

        public DefaultExpressionParser() : this(DefaultMaxStackSize) { }

        public DefaultExpressionParser(int maxStackSize)
        {
            _stack = new Stack<Operation>(maxStackSize);
        }

        private void PushStackToOutput(Stack<IOperationParticipant> output)
        {
            int totalOperations = _stack.Count;
            for (int i = 0; i < totalOperations; i++)
            {
                var op = _stack.Pop();
                if (op.Type == "(")
                {
                    return;
                }
                output.Push(op);
            }
        }

        public ParsingResult<IOperationParticipant> Parse(string expression)
        {
            expression = expression
                            .Trim()
                            .Replace(" ", "")
                            .ToLower();

            if (string.IsNullOrEmpty(expression))
            {
                throw new ArgumentNullException(nameof(expression), "The expression must not be null or empty!");
            }

            int i = 0;
            var result = new ParsingResult<IOperationParticipant>();
            while (i < expression.Length)
            {
                string value = "";
                while (i < expression.Length && (char.IsDigit(expression[i]) || expression[i] == ','))
                {
                    value += expression[i];
                    i++;
                }

                if (!string.IsNullOrEmpty(value))
                {
                    result.Output.Push(new Operand(Convert.ToDouble(value)));
                    value = "";
                }

                if (i < expression.Length && !char.IsDigit(expression[i]))
                {
                    if(expression[i] == ')')
                    {
                        PushStackToOutput(result.Output);
                    }
                    else
                    {
                        value += expression[i];
                    }
                    i++;
                }

                if(!string.IsNullOrEmpty(value))
                {
                    Operation op = AllowedOperations.GetOperationByType(value);
                    if (op == null)
                    {
                        throw new FormatException("Expression contains unsupported operation type.");
                    }

                    if (_stack.Count > 0 && _stack.Peek().Type != "(" && _stack.Peek().CompareTo(op) >= 0)
                    {
                        result.Output.Push(_stack.Pop());
                    }
                    _stack.Push(op);
                }
            }

            PushStackToOutput(result.Output);
            return result;
        }
    }
}
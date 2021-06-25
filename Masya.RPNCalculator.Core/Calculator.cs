using System;
using System.Collections.Generic;
using System.Linq;
using Masya.RPNCalculator.Core.Abstractions;
using Masya.RPNCalculator.Core.Enums;

namespace Masya.RPNCalculator.Core
{
    [Obsolete("Deprecated")]
    public class Calculator : ICalculator, IExpressionParser
    {
        private readonly Stack<string> _output;
        private readonly Stack<string> _operations;
        private readonly List<Operation> _allowedOperations;

        public Calculator()
        {
            _operations = new Stack<string>();
            _output = new Stack<string>();
            _allowedOperations = new List<Operation>(){
                new Operation("(", OperationPriority.VeryLow, null),
                new Operation(")", OperationPriority.VeryLow, null),
                new Operation("+", OperationPriority.Low, (a, b) => b+a),
                new Operation("-", OperationPriority.Low, (a, b) => b-a),
                new Operation("*", OperationPriority.Medium, (a, b) => b*a),
                new Operation("/", OperationPriority.Medium, (a, b) => b/a),
                new Operation("^", OperationPriority.High, (a, b) => Math.Pow(b, a))
            };
        }

        private void PushOperationsToOutput()
        {
            int totalOperations = _operations.Count;
            for (int i = 0; i < totalOperations; i++)
            {
                string operation = _operations.Pop();
                if (operation.Equals("("))
                {
                    return;
                }

                _output.Push(operation);
            }
        }

        public void Reset()
        {
            _output.Clear();
            _operations.Clear();
        }

        public bool IsHighPriorityOperation(string operation)
        {
            if (_operations.Count == 0)
            {
                return true;
            }

            Operation currentOperation = _allowedOperations.First(o => o.Type == operation);
            Operation topOperation = _allowedOperations.First(o => o.Type == _operations.Peek());
            return currentOperation.Priority > topOperation.Priority;
        }

        public double Calculate(ParseResult result)
        {
            int totalIterations = result.Output.Count;
            foreach (string operationType in result.Output)
            {
                Operation currentOperation = _allowedOperations.FirstOrDefault(o => o.Type == operationType);
                if (currentOperation == null)
                {
                    _output.Push(operationType);
                }
                else
                {
                    double operandLeft = Convert.ToDouble(_output.Pop());
                    double operandRight = Convert.ToDouble(_output.Pop());
                    _output.Push(currentOperation.Func(operandLeft, operandRight).ToString());
                }
            }

            return Convert.ToDouble(_output.Pop());
        }

        public ParseResult Parse(string expression)
        {
            expression = expression.Replace(" ", "");
            if (string.IsNullOrEmpty(expression))
            {
                throw new ArgumentException("Expression must not be an empty line.");
            }

            int i = 0;
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
                    _output.Push(value);
                    continue;
                }

                if (expression[i] == '(')
                {
                    _operations.Push(expression[i].ToString());
                    i++;
                    continue;
                }

                if (expression[i] == ')')
                {
                    PushOperationsToOutput();
                    i++;
                    continue;
                }

                while (i < expression.Length && !char.IsDigit(expression[i]) && expression[i] != ')' && expression[i] != '(')
                {
                    value += expression[i];
                    i++;
                }

                if (_allowedOperations.Any(o => o.Type == value))
                {
                    if (!IsHighPriorityOperation(value))
                    {
                        _output.Push(_operations.Pop());
                    }
                    _operations.Push(value);
                    continue;
                }

                Reset();
                throw new FormatException("Expression contains unsupported operations or symbols.");
            }

            PushOperationsToOutput();
            ParseResult result = new ParseResult(_output);
            Reset();
            return result;
        }
    }
}
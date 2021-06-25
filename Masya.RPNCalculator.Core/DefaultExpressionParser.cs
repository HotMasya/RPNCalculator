using System;
using System.Collections.Generic;
using Masya.RPNCalculator.Core.Abstractions;

namespace Masya.RPNCalculator.Core
{
    public class DefaultExpressionParser : IExpressionParser
    {
        private readonly Stack<IOperationParticipant> _stack;
        private const int DefaultMaxStackSize = 256;

        public DefaultExpressionParser() : this(DefaultMaxStackSize) { }

        public DefaultExpressionParser(int maxStackSize)
        {
            _stack = new Stack<IOperationParticipant>(maxStackSize);
        }

        public ParseResult Parse(string expression)
        {
            expression = expression
                            .Trim()
                            .Replace(" ", "")
                            .ToLower();

            if (string.IsNullOrEmpty(expression))
            {
                throw new ArgumentNullException(nameof(expression), "The expression must not be null or empty!");
            }

            throw new NotImplementedException();
        }
    }
}
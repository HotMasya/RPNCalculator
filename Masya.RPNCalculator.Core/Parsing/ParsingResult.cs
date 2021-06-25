using System.Collections.Generic;
using Masya.RPNCalculator.Core.Abstractions;

namespace Masya.RPNCalculator.Core.Parsing
{
    public class ParsingResult<T> where T : class, IOperationParticipant
    {
        public Stack<T> Output { get; init; }
        public ParsingResult()
        {
            Output = new Stack<T>();
        }

        public ParsingResult(Stack<T> _output) : this()
        {
            foreach (T item in _output)
            {
                Output.Push(item);
            }
        }

        public override string ToString()
        {
            string result = "";
            foreach (T item in Output)
            {
                result += item.ToString() + " ";
            }
            return result.TrimEnd();
        }
    }
}

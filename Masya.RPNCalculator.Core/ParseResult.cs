using System.Collections.Generic;

namespace Masya.RPNCalculator.Core
{
    public class ParseResult
    {
        public Stack<string> Output { get; init; }
        public ParseResult(Stack<string> output)
        {
            Output = new Stack<string>();
            foreach (var value in output)
            {
                Output.Push(value);
            }
        }

        public override string ToString()
        {
            string result = "";
            foreach (string item in Output)
            {
                result += item + " ";
            }
            return result.TrimEnd();
        }
    }
}

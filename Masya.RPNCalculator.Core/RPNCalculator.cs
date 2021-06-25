using Masya.RPNCalculator.Core.Abstractions;

namespace Masya.RPNCalculator.Core
{
    public class RPNCalculator
    {
        private readonly ICalculator _calculator;
        private readonly IExpressionParser _parser;

        public RPNCalculator(ICalculator calculator, IExpressionParser parser)
        {
            _calculator = calculator;
            _parser = parser;
        }

        public double Calculate(string expression)
        {
            var parsingResult = _parser.Parse(expression);
            return _calculator.Calculate(parsingResult);
        }
    }
}
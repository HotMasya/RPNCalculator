using Masya.RPNCalculator.Core.Abstractions;
using Masya.RPNCalculator.Core.Calculations;
using Masya.RPNCalculator.Core.Parsing;

namespace Masya.RPNCalculator.Core
{
    public class DefaultCalculatorFactory : ICalculatorFactory
    {
        public ICalculator CreateCalculator()
        {
            return new DefaultCalculator();
        }

        public IExpressionParser CreateExpressionParser()
        {
            return new DefaultExpressionParser();
        }

        public RPNCalculator CreateRPNCalculator()
        {
            return new RPNCalculator(CreateCalculator(), CreateExpressionParser());
        }
    }
}
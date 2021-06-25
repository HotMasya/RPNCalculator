namespace Masya.RPNCalculator.Core.Abstractions
{
    public interface ICalculatorFactory
    {
        ICalculator CreateCalculator();
        IExpressionParser CreateExpressionParser();
        RPNCalculator CreateRPNCalculator();
    }
}
namespace Masya.RPNCalculator.Core.Abstractions
{
    public interface IExpressionParser
    {
        ParseResult Parse(string expression);
    }
}
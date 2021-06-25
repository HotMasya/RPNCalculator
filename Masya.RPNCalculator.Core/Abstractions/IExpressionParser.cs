using Masya.RPNCalculator.Core.Parsing;

namespace Masya.RPNCalculator.Core.Abstractions
{
    public interface IExpressionParser
    {
        ParsingResult<IOperationParticipant> Parse(string expression);
    }
}
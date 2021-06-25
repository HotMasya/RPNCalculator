using Masya.RPNCalculator.Core.Parsing;

namespace Masya.RPNCalculator.Core.Abstractions
{
    public interface ICalculator
    {
        double Calculate(ParsingResult<IOperationParticipant> result);
    }
}
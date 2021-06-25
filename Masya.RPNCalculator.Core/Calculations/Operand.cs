using Masya.RPNCalculator.Core.Abstractions;

namespace Masya.RPNCalculator.Core.Calculations
{
    public class Operand : IOperationParticipant
    {
        public double Value { get; set; }

        public Operand(double value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
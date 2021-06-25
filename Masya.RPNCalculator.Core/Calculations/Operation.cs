using Masya.RPNCalculator.Core.Abstractions;
using Masya.RPNCalculator.Core.Enums;
using System;

namespace Masya.RPNCalculator.Core.Calculations
{
    public class Operation : IOperationParticipant, IComparable
    {
        public string Type { get; set; }
        public OperationPriority Priority { get; set; }
        public Func<double, double, double> Function { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Operation op = (Operation)obj;
            return this.Priority.CompareTo(op.Priority);
        }

        public int CompareTo(Operation op)
        {
            return op == null
                ? 1
                : this.Priority.CompareTo(op.Priority);
        }

        public override string ToString()
        {
            return Type;
        }
    }
}
using System;
using Masya.RPNCalculator.Core.Enums;

namespace Masya.RPNCalculator.Core
{
    public class Operation
    {
        public Func<double, double, double> Func { get; set; }
        public string Type { get; set; }
        public OperationPriority Priority { get; set; }

        public Operation(string type, OperationPriority priority, Func<double, double, double> func)
        {
            Func = func;
            Type = type;
            Priority = priority;
        }
    }
}

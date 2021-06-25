using System;

namespace Masya.ConsoleCalc.Core
{
    public enum OperationPriority
    {
        VeryLow = 1,
        Low = 2,
        Medium = 3,
        High = 4, 
        VeriHigh = 5
    }

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

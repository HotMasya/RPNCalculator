using System.Collections.Generic;
using System;
using System.Linq;
using Masya.RPNCalculator.Core.Enums;
using Masya.RPNCalculator.Core.Calculations;

namespace Masya.RPNCalculator.Core
{
    public static class AllowedOperations
    {
        public static readonly List<Operation> Operations = new List<Operation>(){
            new Operation { Type = "(", Priority = OperationPriority.VeriHigh },
            new Operation { Type = ")", Priority = OperationPriority.VeriHigh },
            new Operation { Type = "+", Priority = OperationPriority.Low,  Function = (a, b) => b + a},
            new Operation { Type = "-", Priority = OperationPriority.Low,  Function = (a, b) => b - a},
            new Operation { Type = "*", Priority = OperationPriority.Medium,  Function = (a, b) => b * a},
            new Operation { Type = "/", Priority = OperationPriority.Medium,  Function = (a, b) => b / a},
            new Operation { Type = "^", Priority = OperationPriority.Medium,  Function = (a, b) => Math.Pow(b, a)}
        };

        public static Operation GetOperationByType(string type)
        {
            return Operations.FirstOrDefault(o => o.Type.Equals(type));
        }
    }
}
using Masya.RPNCalculator.Core;
using System;
using System.Text;

namespace Masya.ConsoleCalc
{
    class Program
    {
        private static bool ShowNotation = false;
        private static DefaultCalculatorFactory Factory = new DefaultCalculatorFactory();

        static void Main(string[] args)
        {
            string expression;
            if (args.Length > 0 && args[0].StartsWith("-"))
            {
                ShowNotation = args[0].IndexOf('n') >= 0;
                //  Other parameters go here
                //  ...

                expression = GetExpression(args, 1);
            }
            else
            {
                expression = GetExpression(args);
            }

            while (string.IsNullOrEmpty(expression))
            {
                Console.Write("Enter expression: ");
                expression = Console.ReadLine();
            }

            if (ShowNotation)
            {
                var parsingResult = Factory.CreateExpressionParser().Parse(expression);
                Console.WriteLine("Expression in reverse polish notation: " + parsingResult.ToString());
                var calculationResult = Factory.CreateCalculator().Calculate(parsingResult);
                Console.WriteLine("{0} = {1}", expression, calculationResult);
            }
            else
            {
                var calculationResult = Factory.CreateRPNCalculator().Calculate(expression);
                Console.WriteLine("{0} = {1}", expression, calculationResult);
            }
        }

        private static string GetExpression(string[] args, int startIndex = 0)
        {
            StringBuilder builder = new StringBuilder(args.Length);
            for (int i = startIndex; i < args.Length; i++)
            {
                builder.Append(args[i]);
            }
            return builder.ToString();
        }
    }
}

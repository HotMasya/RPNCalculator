using System;
using Masya.ConsoleCalc.Core;

namespace Masya.ConsoleCalc
{
    class Program
    {
        private static Calculator calc = new Calculator();

        static void Main(string[] args)
        {
            string expression = "";
            if (args.Length == 0)
            {
                Console.Write("Enter expression to parse: ");
                expression = Console.ReadLine();
            }
            else
            {
                foreach (string arg in args)
                {
                    expression += arg;
                }
            }

            try
            {
                ParseResult result = calc.Parse(expression);
                Console.WriteLine("Output notation: " + result.ToString());
                Console.WriteLine("Calculation result: " + calc.Calculate(result));
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

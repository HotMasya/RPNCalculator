using System;
using Masya.ConsoleCalc.Core;

namespace Masya.ConsoleCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new Calculator();

            string expression = "";
            do
            {
                Console.Write("Enter expression to parse: ");
                expression = Console.ReadLine();
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

            } while (expression.ToLower() != "exit");
        }
    }
}

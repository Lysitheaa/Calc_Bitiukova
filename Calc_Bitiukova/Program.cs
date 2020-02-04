using Calc_Bitiukova.Operations;
using System;


namespace Calc_Bitiukova
{
    class Program
    {
        static void Main(string[] args)
        {
            Init();

            while (true)
            {
                Console.WriteLine($"\nPlease, input an expression using only next characters {SyntaxCorrectivityChecks.AllowedChars}");
                string input = Console.ReadLine();

                if (input == "q")
                    break;

                PrepareData(ref input);

                if (!SyntaxCorrectivityChecks.ApplyAllSyntaxChecks(input, out string message))
                {
                    WriteErrorMessage(message);
                    continue;
                }

                //try
                //{
                    Calculation c = new Calculation(input);
                    Console.WriteLine($"Result: {c.Result}");
                //}
                //catch (Exception e)
                //{
                //    WriteErrorMessage(e.Message);
                //}

            }
        }

        static void Init()
        {
            OperationsContainer.AddOperation(AddOperation.Instance);
            OperationsContainer.AddOperation(SubstractOperation.Instance);
        }

        static void PrepareData(ref string input)
        {
            input = input.Replace(" ", "");
        }

        static void WriteErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

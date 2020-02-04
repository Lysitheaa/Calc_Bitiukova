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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(message);
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                Calculation c = new Calculation(input);
                Console.WriteLine($"Result: {c.Result}");

            }
        }

        static void Init()
        {
        }

        static void PrepareData(ref string input)
        {
            input = input.Replace(" ", "");
        }
    }
}

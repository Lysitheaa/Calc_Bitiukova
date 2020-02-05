using System;
using System.Text.RegularExpressions;
using Calc_Bitiukova.OperationModels;


namespace Calc_Bitiukova
{
    class Program
    {
        static void Main(string[] args)
        {
            Init();

            while (true)
            {
                Console.Write($"Please, input an expression using only ");
                WriteAttantionMessage(OperationUtils.AllowedCharsMessage);
                
                string input = Console.ReadLine();

                if (input == "q")
                    break;

                OperationUtils.PrepareData(ref input);

                if (!ValidationChecks.ApplyAllChecks(input, out string message))
                {
                    WriteErrorMessage(message);
                    Console.WriteLine();
                    continue;
                }

                try
                {
                    Calculation c = new Calculation(input);
                    WriteSuccessMessage("Result: ");
                    Console.WriteLine(c.Result.ToString());
                }
                catch (Exception e)
                {
                    WriteErrorMessage(e.Message);
                }
                Console.WriteLine();
            }
        }

        static void Init()
        {
            OperationsContainer.AddOperation(AddOperation.Instance);
            OperationsContainer.AddOperation(SubstractOperation.Instance);
            OperationsContainer.AddOperation(MultiplyOperation.Instance);
            OperationsContainer.AddOperation(DivisionOperation.Instance);
        }



        static void WriteErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void WriteAttantionMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void WriteSuccessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

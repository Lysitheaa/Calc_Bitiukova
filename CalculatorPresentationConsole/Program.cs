using System;
using CalculatorBLL;
using static CalculatorPresentationConsole.ColorMessageDisplayer;

namespace CalculatorPresentationConsole
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var calculator = new CalculatorFacade();

            while (true)
            {
                WriteAttantionMessage(CalculatorFacade.StartMessage);

                string input = Console.ReadLine();

                if (input == CalculatorFacade.QuitDesignation)
                {
                    break;
                }

                calculator.Calculate(input);

                if (calculator.IsCalculationSuccessful)
                {
                    WriteSuccessMessage(calculator.ResultText);
                }
                else
                {
                    WriteErrorMessage(calculator.CalculationResultMessage);
                }
            }
        }
    }
}

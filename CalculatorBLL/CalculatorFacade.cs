using System;
using CalculatorBLL.Controllers;
using CalculatorBLL.Operations;
using static CalculatorBLL.Utils.OperationUtils;

namespace CalculatorBLL
{
    public class CalculatorFacade
    {
        private const string StartMessagePrefix = "Please, input an expression using only ";
        private const string resultTextPrefix = "Result: ";
        public const string QuitDesignation = "q";

        public static string StartMessage => StartMessagePrefix + AllowedCharsMessage;
        public string ResultText { get; private set; }
        public bool IsCalculationSuccessful { get; private set; }
        public string CalculationResultMessage { get; private set; }


        public CalculatorFacade()
        {
            OperationsContainer.AddOperation(AddOperation.Instance);
            OperationsContainer.AddOperation(SubstractOperation.Instance);
            OperationsContainer.AddOperation(MultiplyOperation.Instance);
            OperationsContainer.AddOperation(DivisionOperation.Instance);
        }

        public void Calculate(string input)
        {
            PrepareData(ref input);

            var validation = new ValidationChecks();
            IsCalculationSuccessful = validation.ApplyAllChecks(input, out string message);
            CalculationResultMessage = message;

            if (IsCalculationSuccessful)
            {
                try
                {
                    var calculation = new Calculation(input);
                    ResultText = string.Concat(resultTextPrefix, calculation.Result.ToString());
                }
                catch (Exception e)
                {
                    IsCalculationSuccessful = false;
                    CalculationResultMessage = e.Message;
                }
            }
        }
    }
}

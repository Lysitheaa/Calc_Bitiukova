using System.Text.RegularExpressions;
using CalculatorBLL.Controllers;

namespace CalculatorBLL.Utils
{
    public static class OperationUtils
    {
        public const string NumberPattrn = @"\d+(?:\.\d+)?";
        public static readonly string AllowedCharsMessage;
        public static readonly string AllowedOperationsPattern;

        static OperationUtils()
        {
            AllowedOperationsPattern = @"\" + string.Join(@"\", OperationsContainer.OperationDesignations) + @"";
            AllowedCharsMessage = string.Concat("numbers with . separator, spaces and symbols: () ",
                string.Join(" ", OperationsContainer.OperationDesignations));
        }

        public static int GetMaxPrecision(double operand1, double operand2, double result)
        {
            string operand1String = operand1.ToString();
            string operand2String = operand2.ToString();
            string resultString = result.ToString();

            if (operand1String.Contains('.') || operand2String.Contains('.'))
            {
                int operand1Precision = operand1String.Length - operand1String.IndexOf(".") - 1;
                int operand2Precision = operand2String.Length - operand2String.IndexOf(".") - 1;

                return operand1Precision > operand2Precision ? operand1Precision : operand2Precision;
            }
            else if (resultString.Contains('.'))
            {
                return resultString.Length - resultString.IndexOf('.') - 1;
            }

            return 0;
        }

        public static void PrepareData(ref string input)
        {
            input = input.Replace(" ", "");
            if (Regex.IsMatch(input, @"^[\." + AllowedOperationsPattern + "]"))
            {
                input = "0" + input;
            }
        }
    }
}

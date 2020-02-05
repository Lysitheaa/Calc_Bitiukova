using System.Text.RegularExpressions;


namespace Calc_Bitiukova.Operations
{
    public static class OperationUtils
    {
        public const string NUMBER_PATTERN = @"\d+(?:\.\d+)?";
        public static readonly string AllowedCharsMessage = "numbers, white space and symbols: " 
            + string.Join(" ", OperationsContainer.OperationDesignations);

        public static int GetMaxPrecision(double a, double b)
        {
            // bad performane solution, but I don't want to deal with shift operators XD
            string aStr = a.ToString();
            string bStr = b.ToString();

            int aPres = aStr.Length - aStr.IndexOf(".");
            int bPres = bStr.Length - bStr.IndexOf(".");

            return aPres > bPres ? aPres : bPres;
        }

        public static void PrepareData(ref string input)
        {
            input = input.Replace(" ", "");
            if (Regex.IsMatch(input, @"^[-+]"))
                input = "0" + input;
        }
    }
}

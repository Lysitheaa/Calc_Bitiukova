using System.Text.RegularExpressions;


namespace Calc_Bitiukova.OperationModels
{
    public static class OperationUtils
    {
        public const string NUMBER_PATTERN = @"\d+(?:\.\d+)?";
        public static readonly string AllowedCharsMessage ;
        public static readonly string AllowedOperationsPattern;

        static OperationUtils()
        {
            AllowedCharsMessage = "numbers with . separator, spaces and symbols: "
                + string.Join(" ", OperationsContainer.OperationDesignations);

            AllowedOperationsPattern = @"[" + string.Join("\\", OperationsContainer.OperationDesignations) + @"]";
        }

        public static int GetMaxPrecision(double a, double b)
        {
            // bad performane solution, but I don't want to deal with shift operators XD
            string aStr = a.ToString();
            string bStr = b.ToString();

            if (!aStr.Contains('.') && !bStr.Contains('.'))
                return 0;

            int aPres = aStr.Length - aStr.IndexOf(".");
            int bPres = bStr.Length - bStr.IndexOf(".");

            return aPres > bPres ? aPres : bPres;
        }

        public static void PrepareData(ref string input)
        {
            input = input.Replace(" ", "");
            if (Regex.IsMatch(input, @"^\.|" + AllowedOperationsPattern))
                input = "0" + input;
        }
    }
}

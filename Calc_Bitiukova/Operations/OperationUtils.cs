using System;
using System.Collections.Generic;
using System.Text;

namespace Calc_Bitiukova
{
    public static class OperationUtils
    {
        public const string NUMBER_PATTERN = @"\d+(?:\.\d+)?";


        public enum OperationPrioriry
        {
            First,
            Second,
            Third
        }

        public static int GetMaxPrecision(double a, double b)
        {
            // bad performane solution, but I don't want to deal with shift operators XD
            string aStr = a.ToString();
            string bStr = b.ToString();

            int aPres = aStr.Length - aStr.IndexOf(".");
            int bPres = bStr.Length - bStr.IndexOf(".");

            return aPres > bPres ? aPres : bPres;
        }
    }
}

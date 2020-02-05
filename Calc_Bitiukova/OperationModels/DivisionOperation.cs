using System;
using static Calc_Bitiukova.OperationModels.OperationUtils;


namespace Calc_Bitiukova.OperationModels
{
    class DivisionOperation : IOperation
    {
        private static readonly Lazy<DivisionOperation> lazy =
    new Lazy<DivisionOperation>(() => new DivisionOperation());

        public static DivisionOperation Instance => lazy.Value;

        public string Designation => "/";

        public OperationPrioriry Priority => OperationPrioriry.First;

        private DivisionOperation() { }

        public double ExecuteBinaryOperation(double a, double b)
        {
            if (b == 0)
                throw new ApplicationException("Cannot divide by zero.");

            return Math.Round(a / b, GetMaxPrecision(a, b));
        }
    }
}

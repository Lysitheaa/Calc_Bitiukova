using System;
using static Calc_Bitiukova.OperationModels.OperationUtils;


namespace Calc_Bitiukova.OperationModels
{
    class MultiplyOperation : IOperation
    {
        private static readonly Lazy<MultiplyOperation> lazy =
            new Lazy<MultiplyOperation>(() => new MultiplyOperation());

        public static MultiplyOperation Instance => lazy.Value;

        public string Designation => "*";

        public OperationPrioriry Priority => OperationPrioriry.First;

        private MultiplyOperation() { }

        public double ExecuteBinaryOperation(double a, double b) => Math.Round(a * b, GetMaxPrecision(a, b));
    }
}

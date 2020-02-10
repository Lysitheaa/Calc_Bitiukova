using System;
using Interfaces;
using CommonData;

namespace CalculatorBLL.Operations
{
    public sealed class DivisionOperation : IOperation
    {
        private static readonly Lazy<DivisionOperation> instance =
            new Lazy<DivisionOperation>(() => new DivisionOperation());

        private DivisionOperation() { }

        public static DivisionOperation Instance => instance.Value;

        public string Designation => "/";

        public OperationPrioriry Priority => OperationPrioriry.First;

        public double ExecuteBinaryOperation(double a, double b)
        {
            if (b == 0)
            {
                throw new ApplicationException("Cannot divide by zero.");
            }

            return a / b;
        }
    }
}
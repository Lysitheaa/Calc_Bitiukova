using System;
using Interfaces;
using CommonData;

namespace CalculatorBLL.Operations
{
    public sealed class AddOperation : IOperation
    {
        private static readonly Lazy<AddOperation> instance =
            new Lazy<AddOperation>(() => new AddOperation());

        private AddOperation() { }

        public static AddOperation Instance => instance.Value;

        public string Designation => "+";

        public OperationPrioriry Priority => OperationPrioriry.Fourth;

        public double ExecuteBinaryOperation(double a, double b) => a + b;

    }
}
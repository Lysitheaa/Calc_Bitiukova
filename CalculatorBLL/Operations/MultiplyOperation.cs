using System;
using Interfaces;
using CommonData;

namespace CalculatorBLL.Operations
{
    public sealed class MultiplyOperation : IOperation
    {
        private static readonly Lazy<MultiplyOperation> instance =
            new Lazy<MultiplyOperation>(() => new MultiplyOperation());

        private MultiplyOperation() { }

        public static MultiplyOperation Instance => instance.Value;

        public string Designation => "*";

        public OperationPrioriry Priority => OperationPrioriry.Second;

        public double ExecuteBinaryOperation(double a, double b) => a * b;
    }
}
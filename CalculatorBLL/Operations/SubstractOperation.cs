using System;
using Interfaces;
using CommonData;

namespace CalculatorBLL.Operations
{
    public sealed class SubstractOperation : IOperation
    {
        private static readonly Lazy<SubstractOperation> instance =
            new Lazy<SubstractOperation>(() => new SubstractOperation());

        private SubstractOperation() { }

        public static SubstractOperation Instance => instance.Value;

        public string Designation => "–";

        public OperationPrioriry Priority => OperationPrioriry.Third;

        public double ExecuteBinaryOperation(double a, double b) => a - b;
    }
}
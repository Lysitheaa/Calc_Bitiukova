﻿using System;
using static Calc_Bitiukova.OperationModels.OperationUtils;


namespace Calc_Bitiukova.OperationModels
{
    public sealed class SubstractOperation : IOperation
    {
        private static readonly Lazy<SubstractOperation> lazy =
            new Lazy<SubstractOperation>(() => new SubstractOperation());

        public static SubstractOperation Instance => lazy.Value;

        public string Designation => "-";

        public OperationPrioriry Priority => OperationPrioriry.Second;

        private SubstractOperation() { }

        public double ExecuteBinaryOperation(double a, double b) => Math.Round(a - b, GetMaxPrecision(a, b));
    }
}
﻿using System;
using static Calc_Bitiukova.OperationUtils;

namespace Calc_Bitiukova
{
    public sealed class AddOperation : IOperation
    {
        private static readonly Lazy<AddOperation> lazy =
            new Lazy<AddOperation>(() => new AddOperation());

        public static AddOperation Instance => lazy.Value;

        public string Designation => "+";

        public OperationPrioriry Priority => OperationPrioriry.Third;

        private AddOperation() { }

        public double ExecuteBinaryOperation(double a, double b) => a + b;
        
    }
}
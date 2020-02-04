using System;
using System.Collections.Generic;
using System.Text;

namespace Calc_Bitiukova
{
    public abstract class Operation //: IOperation
    {
        public enum OperationPrioriry
        {
            First,
            Second
        }

        public abstract OperationPrioriry Priority { get; }

        public abstract string Designation { get; }

        public abstract float ExecuteBinaryOperation(float a, float b);

        //public static abstract AddOperation Instance { get; }
    }
}

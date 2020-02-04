using System;
using System.Collections.Generic;
using System.Text;

namespace Calc_Bitiukova
{
    public enum OperationPrioriry
    {
        First,
        Second
    }

    public interface IOperation
    {
        OperationPrioriry Priority { get; } 
        
        string Designation { get; }

        double ExecuteBinaryOperation(double a, double b);

        public static AddOperation Instance { get; }

       // bool SyntaxCheck();

        // string ErrorMessage();
    }
}

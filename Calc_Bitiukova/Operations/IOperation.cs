using System;
using System.Collections.Generic;
using System.Text;

namespace Calc_Bitiukova
{

    public interface IOperation
    {
        public static AddOperation Instance { get; }

        OperationUtils.OperationPrioriry Priority { get; } 
        
        string Designation { get; }

        double ExecuteBinaryOperation(double a, double b);


        // bool SyntaxCheck();
        // string ErrorMessage();
    }
}

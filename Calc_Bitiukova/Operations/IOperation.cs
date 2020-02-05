namespace Calc_Bitiukova.Operations
{
    public interface IOperation
    {
        public static AddOperation Instance { get; }

        OperationPrioriry Priority { get; } 
        
        string Designation { get; }

        double ExecuteBinaryOperation(double a, double b);


        // bool SyntaxCheck(string input);
        // string GetErrorMessage { get; };
    }
}

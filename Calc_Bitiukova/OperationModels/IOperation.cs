namespace Calc_Bitiukova.OperationModels
{
    public interface IOperation
    {
        public static AddOperation Instance { get; }

        OperationPrioriry Priority { get; } 
        
        string Designation { get; }

        double ExecuteBinaryOperation(double a, double b);


        // bool ValidationCheck(string input);
        // string GetErrorMessage { get; };
    }
}

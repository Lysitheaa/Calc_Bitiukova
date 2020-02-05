using System.Collections.Generic;
using System.Linq;


namespace Calc_Bitiukova.OperationModels
{
    public static class OperationsContainer
    {
        private static Dictionary<string, IOperation> _operations = new Dictionary<string, IOperation>();
        
        public static string[] OperationDesignations => _operations.Keys.ToArray();

        public delegate double ExecuteBinaryOperationHandler(double a, double b); // where T: notnull;

        public static void AddOperation(IOperation operation)
        {
            _operations[operation.Designation] = operation;
        }

        public static ExecuteBinaryOperationHandler GetExecutionMethodByDesignation(string designation) =>
            _operations[designation].ExecuteBinaryOperation;

        public static string[] GetOperationsByPriority(OperationPrioriry priority) =>
            _operations.Where(o => o.Value.Priority == priority).Select(o => o.Key).ToArray();
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Calc_Bitiukova.Operations
{
    public static class AvailableOperations
    {
       // private static List<IOperation> _allOperations = new List<IOperation>();
        //private static List<string> _operationDesignations = new List<string>();

        private static Dictionary<string, IOperation> _operations = new Dictionary<string, IOperation>();
        
        public static string[] OperationDesignations => _operations.Keys.ToArray();

        public delegate double ExecuteBinaryOperationHandler(double a, double b); // where T: notnull;

        public static void AddOperation(IOperation operation)
        {
            _operations[operation.Designation] = operation;
           // _operationDesignations.Add(operation.Designation);
           // _allOperations.Add(operation);
        }

        public static ExecuteBinaryOperationHandler GetExecutionMethodByDesignation(string designation) =>
            _operations[designation].ExecuteBinaryOperation;

        internal static string[] GetOperationsByPriority(Calc_Bitiukova.OperationPrioriry priority) =>
            _operations.Where(o => o.Value.Priority == priority).Select(o => o.Key).ToArray();
        
        //=>
        //(from o in _operations
        //where o.Value.Priority == priority
        //select o.Key).ToArray();
    }
}

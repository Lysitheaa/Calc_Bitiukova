using System.Collections.Generic;
using System.Linq;
using CommonData;
using Interfaces;

namespace CalculatorBLL.Controllers
{
    public delegate double ExecuteBinaryOperationHandler(double operand1, double operand2);

    public class OperationsContainer
    {
        private static readonly Dictionary<string, IOperation> _operations = new Dictionary<string, IOperation>();

        public static string[] OperationDesignations => _operations.Keys.ToArray();

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
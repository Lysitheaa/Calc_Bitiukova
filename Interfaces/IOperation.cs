using CommonData;

namespace Interfaces
{
    public interface IOperation
    {
        public OperationPrioriry Priority { get; }

        public string Designation { get; }

        double ExecuteBinaryOperation(double a, double b);
    }
}

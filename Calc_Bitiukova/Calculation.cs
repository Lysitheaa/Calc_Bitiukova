using Calc_Bitiukova.Operations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace Calc_Bitiukova
{
    class Calculation
    {
        private static readonly string[] _operations;

        public double Result { get; private set; }

        static Calculation()
        {
            _operations = AvailableOperations.OperationDesignations;
        }

        public Calculation(string input)
        {
            Result = simpleCalculation(input);
        }

        private double simpleCalculation(string input)
        {
            List<string> inValuesStr = new List<string> (input.Split(_operations, StringSplitOptions.RemoveEmptyEntries));
            List<string> inOperations = new List<string>(Regex.Split(input, @"\d+"));
            //Console.WriteLine(string.Join(" ", inValues));
            //Console.WriteLine(string.Join("", inOperations));

            List<double> inValuesDouble = new List<double>();

            foreach (OperationPrioriry p in Enum.GetValues(typeof(OperationPrioriry)))
                foreach (string designation in AvailableOperations.GetOperationsByPriority(p))
                    atomicCalculation(inValuesDouble, inOperations, designation);


            return 0;
                //inValues.Count == 1?
                //inValues[0].tod;
        }

        private static void atomicCalculation(List<double> values, List<string> operations, string designation)
        {
            int idx = operations.IndexOf(designation);
            //bool isParsingOk = true;
            while (idx > 0)
            {
                idx = operations.IndexOf(designation);

                //isParsingOk = double.TryParse(values[idx], out double a);
                //isParsingOk = double.TryParse(values[idx + 1], out double b) ? isParsingOk : false;

                //if (!isParsingOk)
                //    throw new Exception("Cannot parse values.");

                double res = AvailableOperations.GetExecutionMethodByDesignation(designation)?.Invoke(a, b) ?? 
                    throw new Exception($"Operation {designation} not found.");

                operations.RemoveAt(idx);
                values.RemoveAt(idx + 1);
                values[idx] = res;
            }
        }
    }
}

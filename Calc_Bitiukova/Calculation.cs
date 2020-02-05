using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Calc_Bitiukova.Operations;
using static Calc_Bitiukova.Operations.OperationUtils;


namespace Calc_Bitiukova
{
    class Calculation
    {
        private static readonly string[] _operations;

        public double Result { get; private set; }

        static Calculation()
        {
            if (OperationsContainer.OperationDesignations.Length > 0)
                _operations = OperationsContainer.OperationDesignations;
            else
                throw new ApplicationException("No operations are defined");
        }

        public Calculation(string input)
        {
            Result = SimpleCalculation(input);
        }

        private double SimpleCalculation(string input)
        {
            List<string> inOperations = new List<string>(Regex.Split(input, NUMBER_PATTERN).Where(v => v != string.Empty));
            List<string> inValuesStr = new List<string> (input.Split(_operations, StringSplitOptions.RemoveEmptyEntries));
            List<double> inValuesDouble = new List<double>();
            ParseValues(inValuesStr, ref inValuesDouble);
            
            foreach (OperationPrioriry p in Enum.GetValues(typeof(OperationPrioriry)))
                foreach (string designation in OperationsContainer.GetOperationsByPriority(p))
                    OneOperationCalc(inValuesDouble, inOperations, designation);
            
            if (inValuesDouble.Count == 1 && inOperations.Count == 0)
                return inValuesDouble[0];
            else
                throw new ApplicationException("Extra values or operations were appeared somehow ¯\\_(ツ)_/¯");
        }

        private void OneOperationCalc(List<double> values, List<string> operations, string designation)
        {
            int idx = operations.FindIndex(v => v.Equals(designation));
            double res;

            while (idx >= 0)
            {
                res = OperationsContainer
                    .GetExecutionMethodByDesignation(designation)
                    ?.Invoke(values[idx], values[idx + 1]) 
                    ?? throw new ApplicationException($"Operation {designation} not found.");

                operations.RemoveAt(idx);
                values.RemoveAt(idx + 1);
                values[idx] = res;

                idx = operations.IndexOf(designation);
            }
        }

        private void ParseValues(List<string> inValuesStr, ref List<double> inValuesDouble)
        {
            try
            {
                inValuesDouble = inValuesStr.Select(v => double.Parse(v)).ToList();
            }
            catch (Exception e)
            {
                throw new ApplicationException($"Cannot parse some values from {string.Join(" ", inValuesStr)} to double.\n{e.Message}");
            }
        }
    }
}

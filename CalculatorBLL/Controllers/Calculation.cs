using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CommonData;
using static CalculatorBLL.Utils.OperationUtils;

namespace CalculatorBLL.Controllers
{
    public class Calculation
    {
        private static readonly string[] _operations;
        private List<string> inputtedOperations, inputtedValuesString;
        private List<double> inputtedValuesDouble;

        public double Result { get; private set; }

        static Calculation()
        {
            _operations = OperationsContainer.OperationDesignations;
        }

        public Calculation(string input)
        {
            Result = CalculationWithBrackets(input);
        }

        private double CalculationWithBrackets(string input)
        {
            int openBracketIdx, closeBracketIdx, inBracketsExpressionLength;
            string simpleExpression;
            double inBraketsResult;


            while (input.Contains('('))
            {
                openBracketIdx = input.LastIndexOf('(');
                closeBracketIdx = input.IndexOf(')', openBracketIdx);
                inBracketsExpressionLength = closeBracketIdx - openBracketIdx - 1;
                simpleExpression = input.Substring(openBracketIdx + 1, inBracketsExpressionLength);
                inBraketsResult = SimpleCalculation(simpleExpression);

                input = input.Replace(
                    input.Substring(openBracketIdx, inBracketsExpressionLength + 2),
                    inBraketsResult.ToString());
            }

            return SimpleCalculation(input);
        }

        private double SimpleCalculation(string input)
        {
            InitializeLists(input);

            foreach (OperationPrioriry priority in Enum.GetValues(typeof(OperationPrioriry)))
                foreach (string designation in OperationsContainer.GetOperationsByPriority(priority))
                    if (inputtedOperations.Contains(designation) && inputtedOperations.Count > 0)
                    {
                        OneOperationCalculation(designation);
                    }

            if (inputtedValuesDouble.Count == 1 && inputtedOperations.Count == 0)
            {
                return inputtedValuesDouble[0];
            }
            else
            {
                throw new ApplicationException("Extra values or operations were appeared somehow ¯\\_(ツ)_/¯");
            }
        }

        private void InitializeLists(string input)
        {
            inputtedOperations = new List<string>(Regex.Split(input, NumberPattrn).Where(v => v != string.Empty));
            inputtedValuesString = new List<string>(input.Split(_operations, StringSplitOptions.RemoveEmptyEntries));
            inputtedValuesDouble = new List<double>();
            ParseValues();
        }

        private void OneOperationCalculation(string designation)
        {
            double result, operand1, operand2;
            int idx;

            while (inputtedOperations.Contains(designation))
            {
                idx = inputtedOperations.IndexOf(designation);
                operand1 = inputtedValuesDouble[idx];
                operand2 = inputtedValuesDouble[idx + 1];

                result = OperationsContainer
                   .GetExecutionMethodByDesignation(designation)
                   ?.Invoke(operand1, operand2)
                   ?? throw new ApplicationException($"Operation {designation} not found.");
                result = Math.Round(result, GetMaxPrecision(operand1, operand2, result));

                inputtedOperations.RemoveAt(idx);
                inputtedValuesDouble.RemoveAt(idx + 1);
                inputtedValuesDouble[idx] = result;
            }
        }

        private void ParseValues()
        {
            try
            {
                inputtedValuesDouble = inputtedValuesString.Select(v => double.Parse(v)).ToList();
            }
            catch (Exception e)
            {
                throw new ApplicationException("Cannot parse some values from"
                    + $" {string.Join(" ", inputtedValuesString)} to double.\n{e.Message}");
            }
        }
    }
}

using System.Collections.Generic;
using System.Text.RegularExpressions;
using static CalculatorBLL.Utils.OperationUtils;

namespace CalculatorBLL.Controllers
{
    public delegate bool ChecksHandler(string input);

    public class ValidationChecks
    {
        private static readonly Regex NotAllowedCharPattern = new Regex(@"[^()" + NumberPattrn + AllowedOperationsPattern + @"]", RegexOptions.Compiled);
        private Dictionary<string, string> Messages = new Dictionary<string, string>
        {
            ["OK"] = "All checks are passed successfully.",
            ["AllowedCharactersCheck"] = "Please, use only allowed characters.",
            ["ExpressionCheck"] = "Oops.. Something went wrong with your expression. Please, check your input string.",
            ["BracketsCheck"] = "Oops.. Something went wrong with breackets in your expression. Please, check it."
        };

        private ChecksHandler checks;
        public event ChecksHandler Checks
        {
            add
            {
                checks += value;
                Messages[value.Method.Name] = $"Check in method {value.Method.Name} failed.";
            }
            remove
            {
                checks -= value;
                Messages.Remove(value.Method.Name);
            }
        }

        public ValidationChecks()
        {
            checks += ExpressionCheck;
            checks += BracketsCheck;
            checks += AllowedCharactersCheck;
        }

        public bool BracketsCheck(string input)
        {
            string allBrackets = Regex.Replace(input, @"[^()]", "");
            Stack<char> bracketsStack = new Stack<char>();

            foreach (char c in allBrackets)
            {
                if (c == '(')
                {
                    bracketsStack.Push(c);
                }
                else if (bracketsStack.Count > 0)
                {
                    bracketsStack.Pop();
                }
                else
                {
                    return false;
                }
            }

            return bracketsStack.Count == 0;
        }

        public bool ExpressionCheck(string input) =>
            Regex.IsMatch(
                input,
                @"^\(?" + NumberPattrn + @"(?:\(*[" + AllowedOperationsPattern + @"]\(*" + NumberPattrn + @"\)*)*$");

        public bool AllowedCharactersCheck(string input) => !NotAllowedCharPattern.IsMatch(input);

        public bool ApplyAllChecks(string input, out string message)
        {
            message = Messages["OK"];

            foreach (ChecksHandler e in checks.GetInvocationList())
                if (e?.Invoke(input) == false)
                {
                    message = Messages[e.Method.Name];
                }

            return message == Messages["OK"];
        }

    }
}

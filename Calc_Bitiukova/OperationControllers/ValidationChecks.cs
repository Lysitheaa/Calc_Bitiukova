﻿using System.Collections.Generic;
using System.Text.RegularExpressions;
using Calc_Bitiukova.OperationModels;
using static Calc_Bitiukova.OperationModels.OperationUtils;


namespace Calc_Bitiukova
{
    public static class ValidationChecks
    {
        
        private static readonly string AllowedChars; 
        private static readonly string NotAllowedCharPattern;
        //private static readonly string AllowedOperationsPattern11;

        public delegate bool ChecksHandler(string input);
        private static event ChecksHandler _checkAll;
        public static event ChecksHandler CheckAll
        {
            add
            {
                _checkAll += value;
                _messages[value.Method.Name] = $"Check in method {value.Method.Name} failed.";
            }
            remove
            {
                _checkAll -= value;
                _messages.Remove(value.Method.Name);
            }
        }
        
        private static Dictionary<string, string> _messages = new Dictionary<string, string>
        {
            ["OK"] = "All checks are passed successfully.",
            ["AllowedCharactersCheck"] = "Please, use only allowed characters.",
            ["ExpressionCheck"] = "Oops.. Something went wrong with your expression. Please, check your input string.",
            ["BracketsCheck"] = "Oops.. Something went wrong with breackets in your expression. Please, check it."
        };

        static ValidationChecks()
        {
            _checkAll += ExpressionCheck;
            _checkAll += BracketsCheck;
            _checkAll += AllowedCharactersCheck;

            //AllowedOperationsPattern11 = @"[" + string.Join("\\", OperationsContainer.OperationDesignations) + @"]";
            AllowedChars = @"0-9 \." + AllowedOperationsPattern;
            NotAllowedCharPattern = @"[^" + AllowedChars + @"]";
        }
        
        public static bool BracketsCheck(string input)
        {
            string allBrackets = Regex.Replace(input, @"[^()]", "");
            Stack<char> bracketsStack = new Stack<char>();
            
            foreach(char c in allBrackets)
            {
                if (c == '(')
                    bracketsStack.Push(c);
                else if (bracketsStack.Count > 0)
                    bracketsStack.Pop();
                else
                    return false;
            }
            
            return bracketsStack.Count == 0;
        }

        public static bool ExpressionCheck(string input) => 
            Regex.IsMatch(
                input,
                @"^" + NUMBER_PATTERN + @"(" + AllowedOperationsPattern + NUMBER_PATTERN + @")*$"); 

        public static bool AllowedCharactersCheck(string input) =>
            !Regex.IsMatch(input, NotAllowedCharPattern);

        public static bool ApplyAllChecks(string input, out string message)
        {
            message = _messages["OK"];

            foreach(ChecksHandler e in _checkAll.GetInvocationList())
                if (e?.Invoke(input) == false)
                    message = _messages[e.Method.Name];

            return message == _messages["OK"];
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HappyCoding.Calculator
{
    public class AdvancedCalculator
    {
        private List<string> _calculateOperators;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdvancedCalculator"/> class.
        /// </summary>
        public AdvancedCalculator()
        {
            _calculateOperators = new List<string>
            {
                "+",
                "-",
                "*",
                "/",
            };
        }

        /// <summary>
        /// Determines whether the expression can be calculated.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns>
        ///   <c>true</c> if expression is valid <c>true</c>; otherwise, <c>false</c>.
        /// </returns>
        public bool IsValidExpression(string expression)
        {
            var patternValidation = @"^([0-9+\-\/*(),]+[0-9)]{1})$";

            if (!(expression.Count(x => x == '(') == expression.Count(x => x == ')')) || !Regex.IsMatch(expression, patternValidation))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Calculates the specified expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns>Result.</returns>
        public double Calculate(string expression)
        {
            if (!IsValidExpression(expression))
            {
                return double.NaN;
            }
            var result = CalculateParenthesis(expression);

            result = CalculateBasicOperations(result);
            return double.Parse(result);
        }

        /// <summary>
        /// Calculates the basic operations.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <remarks>
        /// <list type="number">
        /// <item>
        /// PEMDAS.
        /// </item>
        /// <item>
        /// Calculate expresssion left to right.
        /// </item>
        /// </list>
        /// </remarks>
        /// <returns>string with one calculated expression.</returns>
        private string CalculateBasicOperations(string expression)
        {
            //string result = expression;
            if (expression.Contains("/") && expression.Contains("*") && expression.IndexOf("*") < expression.IndexOf("/"))
            {
                expression = CalculateBasicOperation(expression, "*");
                //result = CalculateBasicOperation(expression, "/");
            }
            else if (expression.Contains("/") && expression.Contains("*") && expression.IndexOf("/") < expression.IndexOf("*"))
            {
                expression = CalculateBasicOperation(expression, "/");
                //result = CalculateBasicOperation(expression, "*");
            }
            else if (expression.Contains("/"))
            {
                expression = CalculateBasicOperation(expression, "/");
            }
            else if (expression.Contains("*"))
            {
                expression = CalculateBasicOperation(expression, "*");
            }

            if (expression.Contains("-") && expression.Contains("+") && expression.IndexOf("+") < expression.IndexOf("-"))
            {
                expression = CalculateBasicOperation(expression, "+");
            }
            else if (expression.Contains("-") && expression.Contains("+") && expression.IndexOf("-") < expression.IndexOf("+"))
            {
                expression = CalculateBasicOperation(expression, "-");
            }
            else if (expression.Contains("-"))
            {
                expression = CalculateBasicOperation(expression, "-");
            }
            else if (expression.Contains("+"))
            {
                expression = CalculateBasicOperation(expression, "+");
            }
            return expression;

        }

        private string CalculateBasicOperation(string expression, string expressionOperator)
        {
            var pattern = $"([0-9,]+[{expressionOperator}][0-9,-]+)";
            var regex = new Regex(pattern);
            var enumerator = regex.Matches(expression).GetEnumerator();
            double currentValue = double.NaN;
            while (enumerator.MoveNext())
            {
                string match = enumerator.Current.ToString();
                string[] elements = match.Split(expressionOperator);
                for (int i = 0; i < elements.Length; i++)
                {
                    if (string.IsNullOrEmpty(elements[i]))
                    {
                        continue;
                    }
                    double val = double.Parse(elements[i]);
                    if (expressionOperator.Equals("*", StringComparison.OrdinalIgnoreCase))
                    {
                        if (currentValue.Equals(double.NaN))
                        {
                            currentValue = val;
                        }
                        else
                        {
                            currentValue *= val;
                        }
                    }
                    else if (expressionOperator.Equals("/", StringComparison.OrdinalIgnoreCase))
                    {
                        if (currentValue.Equals(double.NaN))
                        {
                            currentValue = val;
                        }
                        else
                        {
                            if (val.Equals(0d))
                            {
                                throw new DivideByZeroException();
                            }
                            currentValue /= val;
                        }
                    }
                    else if (expressionOperator.Equals("+", StringComparison.OrdinalIgnoreCase))
                    {
                        if (currentValue.Equals(double.NaN))
                        {
                            currentValue = val;
                        }
                        else
                        {
                            currentValue += val;
                        }
                    }
                    else if (expressionOperator.Equals("-", StringComparison.OrdinalIgnoreCase))
                    {
                        if (currentValue.Equals(double.NaN))
                        {
                            currentValue = val;
                        }
                        else
                        {
                            currentValue -= val;
                        }
                    }
                }
                expression = expression.Replace(match, currentValue.ToString());
                if (_calculateOperators.Any<string>(o => match.Contains(o)) && !_calculateOperators.Any<string>(o => expression.StartsWith(o)))
                {
                    expression = CalculateBasicOperations(expression);
                }
            }

            return expression;
        }

        /// <summary>
        /// Calculates the parenthesis.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        private string CalculateParenthesis(string expression)
        {
            var pattern = $"[(][0-9+-/*]*[)]";
            var regex = new Regex(pattern);
            var enumerator = regex.Matches(expression).GetEnumerator();
            while (enumerator.MoveNext())
            {
                var currentExpression = enumerator.Current.ToString();
                var cleanedCurrentExpression = currentExpression.Replace("(", "").Replace(")", "");
                var temp = CalculateBasicOperations(cleanedCurrentExpression);
                expression = expression.Replace(currentExpression, temp.ToString());

            }
            if (expression.Contains("("))
            {
                expression = CalculateParenthesis(expression);
            }
            return expression;
        }

    }
}

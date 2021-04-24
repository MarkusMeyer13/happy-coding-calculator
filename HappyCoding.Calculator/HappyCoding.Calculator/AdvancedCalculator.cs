using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace HappyCoding.Calculator
{
    public class AdvancedCalculator
    {
        private List<string> _calculateOperatotors;

        public AdvancedCalculator()
        {
            _calculateOperatotors = new List<string>
            {
                "+",
                "-",
                "*",
                "/",
            };
        }

        public double Calculate(string expression)
        {
            var result = CalculateBasicOperations(expression);
            return double.Parse(result);
        }

        private string CalculateBasicOperations(string expression)
        {
            string result = string.Empty;
            if(expression.IndexOf("*") < expression.IndexOf("/"))
            {
                result = CalculateBasicOperation(expression, "*");
                result = CalculateBasicOperation(result, "/");
            }
            else
            {
                result = CalculateBasicOperation(result, "/");
                result = CalculateBasicOperation(expression, "*");
            }
            if (expression.IndexOf("+") < expression.IndexOf("-"))
            {
                result = CalculateBasicOperation(result, "+");
                result = CalculateBasicOperation(result, "-");
            }
            else
            {
                result = CalculateBasicOperation(result, "-");
                result = CalculateBasicOperation(result, "+");
            }

            return result;
        }

        private string Multiple(string expression)
        {
            var pattern = "([0-9,]*[*][0-9,]+)";
            var regex = new Regex(pattern);
            var enumerator = regex.Matches(expression).GetEnumerator();
            while (enumerator.MoveNext())
            {
                string match = enumerator.Current.ToString();
                string[] elements = match.Split('*');
                double currentValue = 1d;
                for (int i = 0; i < elements.Length; i++)
                {
                    double val = double.Parse(elements[i]);
                    currentValue = currentValue * val;
                }
                expression = expression.Replace(match, currentValue.ToString());
            }

            return expression;
        }

        private string CalculateBasicOperation(string expression, string expressionOperator)
        {
            var pattern = $"([0-9,]*[{expressionOperator}][0-9,]+)";
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
                            currentValue = currentValue * val;
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
                            currentValue = currentValue / val;
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
                            currentValue = currentValue + val;
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
                            currentValue = currentValue - val;
                        }
                    }
                }
                //if (match.ToString().StartsWith(expressionOperator))
                //if (match.ToString().StartsWith("+") || match.ToString().StartsWith("-") || match.ToString().StartsWith("/") || match.ToString().StartsWith("*"))
                if (_calculateOperatotors.Any<string>(o => match.StartsWith(o)))
                {
                    expression = CalculateBasicOperations(currentValue.ToString());
                    //expression = CalculateBasicOperation(currentValue.ToString(), match.Substring(0, 1));
                }
                else
                {
                    expression = expression.Replace(match, currentValue.ToString());
                }
            }

            return expression;
        }

    }
}

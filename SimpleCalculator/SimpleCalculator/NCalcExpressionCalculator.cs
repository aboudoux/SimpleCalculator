using System;
using NCalc;

namespace SimpleCalculator
{
    public class NCalcExpressionCalculator : IExpressionCalculator
    {
        public NCalcExpressionCalculator()
        {
            
        }
        public string Evaluate(string expression)
        {
            try
            {
                var finalExpression = expression.Replace(",", ".").Replace("x", "*");
                var calExpression = new Expression(finalExpression);
                return calExpression.Evaluate().ToString();
            }
            catch (Exception)
            {
                return expression;
            }
        }
    }
}
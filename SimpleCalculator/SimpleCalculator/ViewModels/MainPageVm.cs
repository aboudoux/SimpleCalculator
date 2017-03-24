using System;
using Xamarin.Forms;

namespace SimpleCalculator.ViewModels
{
    public class MainPageVm : ViewModel
    {
        private readonly IExpressionCalculator _calculator;

        public Command NumberButton0 { get; }
        public Command NumberButton1 { get; }
        public Command NumberButton2 { get; }
        public Command NumberButton3 { get; }
        public Command NumberButton4 { get; }
        public Command NumberButton5 { get; }
        public Command NumberButton6 { get; }
        public Command NumberButton7 { get; }
        public Command NumberButton8 { get; }
        public Command NumberButton9 { get; }
        public Command CommaButton { get; }
        public Command PlusButton { get; }
        public Command MinusButton { get; }
        public Command MultiplyButton { get; }
        public Command DivideButton { get; }
        public Command EqualButton { get; }
        public Command ClearButton { get; }
        public Command DelButton { get; }
        public Command PercentButton { get; }

        public MainPageVm(IExpressionCalculator calculator) 
        {
            if (calculator == null) throw new ArgumentNullException(nameof(calculator));
            _calculator = calculator;

            NumberButton0 = ExpressionAppenderCommand('0');
            NumberButton1 = ExpressionAppenderCommand('1');
            NumberButton2 = ExpressionAppenderCommand('2');
            NumberButton3 = ExpressionAppenderCommand('3');
            NumberButton4 = ExpressionAppenderCommand('4');
            NumberButton5 = ExpressionAppenderCommand('5');
            NumberButton6 = ExpressionAppenderCommand('6');
            NumberButton7 = ExpressionAppenderCommand('7');
            NumberButton8 = ExpressionAppenderCommand('8');
            NumberButton9 = ExpressionAppenderCommand('9');
            CommaButton = ExpressionAppenderCommand(',');
            PercentButton = ExpressionAppenderCommand('%');

            DivideButton = ExpressionAppenderCommand('/');
            MultiplyButton = ExpressionAppenderCommand('x');
            MinusButton = ExpressionAppenderCommand('-');
            PlusButton = ExpressionAppenderCommand('+');

            EqualButton = new Command(Calculate);
            DelButton = new Command(RemoveLastChar);
            ClearButton = new Command((Clear));                              
        }       

        private string _expression = "0";

        public string Expression
        {
            get { return _expression; }
            set
            {
                SetProperty(ref _expression, value);
            }
        }

      

        private void AddToOperation(char value)
        {
            if( value == ',' && Expression.Contains(","))
                return;            

            if (Expression == "0")
                Expression = value.ToString();
            else
                Expression += value;            
        }

        private void Clear()
        {
            Expression = "0";            
        }

        private void RemoveLastChar() 
        {
            Expression = Expression.Length == 1 ? "0" : Expression.Remove(Expression.Length - 1);
        }

        private void Calculate()
        {
            Expression = _calculator.Evaluate(Expression);
        }

        private Command ExpressionAppenderCommand(char charToAppend)
        {            
            return new Command(()=>AddToOperation(charToAppend));
        }
    }
}

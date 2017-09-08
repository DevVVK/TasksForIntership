using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Calculator.Interface;
using Calculator.Enumerables;

namespace Calculator.View
{
    public partial class MainFormCalculator : Form, IViewCalculator
    {
        public event EventHandler<CommandPressedEventArgs> CommandPressed;

        public string Output
        {
            set => tbxDigit.Text = value;
            get => tbxDigit.Text;
        }

        public string Expression
        {
            set => tbxExpression.Text = value;
            get => tbxExpression.Text;
        }

        public MainFormCalculator()
        {
            InitializeComponent();
            InitializeDyctNummBumbers();
            tbxDigit.Focus();
            _memoryNumber = "0";
            _flagOperaion = true;
            _flagPressDigit = false;

            Output = "0";
        }

        /// <summary>
        /// Обработчик исполнения команды
        /// </summary>
        /// <param name="command">команда</param>
        private void PressCommand(OperatorEnum command)
        {
            if (Output == "NaN")
            {
                return;
            }

            var operation = new CommandPressedEventArgs(command);

            if (_countLeftBrackets == 0)
            {
                CommandPressed?.Invoke(this, operation);
            }
        }

        private bool _flagPressDigit;

        /// <summary>
        /// Обработка ввода символов из интерфейса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PressDigitClick(object sender, EventArgs e)
        {
            if (Output.Length == 10 && _flagPressDigit)
            {
                return;
            }

            if (Output == "NaN")
            {
                return;
            }

            var btnDigit = sender as Button;

            if (btnDigit == null) return;
            _flagOperaion = true;

            EnterDigitHandler(btnDigit.Text);
        }

        /// <summary>
        /// Обработчик ввода символов с клавиатуры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PressDigitKey(object sender, KeyEventArgs e)
        {
            if (Output.Length == 10 && _flagPressDigit)
            {
                return;
            }

            if (Output == "NaN")
            {
                return;
            }

            _flagOperaion = true;

            var pressedKey = _numbersNumm.ContainsKey(e.KeyCode) ? _numbersNumm[e.KeyCode] : e.KeyCode;
            var key = (char) pressedKey;
            
            EnterDigitHandler(key.ToString());
        }

        /// <summary>
        /// Обработка введенных символов
        /// </summary>
        /// <param name="digit"></param>
        private void EnterDigitHandler(string digit)
        {
            if (_flagPressDigit)
            {
                if (Output.Length == 1 && Output[0] == '0' && digit == "0")
                {
                    return;
                }

                Output += digit;
            }
            else
            {
                Output = "";
                Output += digit;

                if (Output.Length == 1 && Output.Contains("0"))
                {
                    return;
                }

                _flagPressDigit = true;
            }
        }

        /// <summary>
        /// Для олучения символа операции из атрибутов членов перечисления операторов
        /// </summary>
        /// <param name="operation">операция</param>
        /// <returns></returns>
        private string GetOperationSymbol(OperatorEnum operation)
        {
            return GetDescriptionName(operation);
        }

        /// <summary>
        /// Добавляет символ операции в вычисляемое выражение
        /// </summary>
        /// <param name="symbol">символ операции</param>
        private void SetOperationSymbol(string symbol)
        {
            if (Output == "NaN")
            {
                return;
            }

            if (Expression.Length > 0 && Expression[Expression.Length - 1] == ')')
            {
                Expression += symbol;
            }
            else if (_flagOperaion)
            {
                if (Output == "NaN")
                {
                    return;
                }

                Expression += GetNegativeValueInBrackets(Output, false);
                Expression += symbol;

                _flagOperaion = false;
                _flagPressDigit = false;
            }
            else
            {
                Expression = Expression.Remove(Expression.Length - 3);
                Expression = Expression.Insert(Expression.Length, symbol);
            }
        }

        /// <summary>
        /// Для обертки в скобки отрицательного числа 
        /// </summary>
        /// <param name="output"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        private string GetNegativeValueInBrackets(string output, bool operation)
        {
            if (decimal.Parse(output) > 0 && !operation)
            {
                return output;
            }

            if (decimal.Parse(output) < 0 && !operation)
            {
                return string.Concat("(", output, ")");
            }

            if (decimal.Parse(output) < 0 && operation)
            {
                return string.Concat("(", output, ")", ")");
            }

            return output + ")";
        }

        private void ResultButton_Click(object sender, EventArgs e)
        {
            if (Output == "NaN")
            {
                return;
            }
            if (decimal.Parse(Output) < 0)
            {
                Output = "(" + Output + ")";
            }

            PressCommand(OperatorEnum.Result);

            Expression = "";

            _flagOperaion = true;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Output = "0";

            Expression = "";

            _flagPressDigit = false;

            _countLeftBrackets = 0;

            lblCountBrackets.Text = _countLeftBrackets.ToString();
        }

        private void ClearSymbolButton_Click(object sender, EventArgs e)
        {
            if (Output == "NaN")
            {
                return;
            }

            if (Output.Length > 1)
            {
                Output = Output.Remove(Output.Length - 1);
            }
            else
            {
                Output = "0";

                _flagPressDigit = false;
            }
        }

        private void ClearLastButton_Click(object sender, EventArgs e)
        {
            Output = "0";

            _flagPressDigit = false;
        }

        /// <summary>
        /// Для вставки локальной функции 
        /// </summary>
        /// <param name="func">функция</param>
        private void GetExpressionLocalFunctions(OperatorEnum func)
        {
            if (Output == "NaN")
            {
                return;
            }

            string exprInBrackets;

            if (Expression.Length > 0 && Expression[Expression.Length - 1] == ')')
            {
                exprInBrackets = GetExpressionWithoutBrackets(Expression);
            }
            else
            {
                exprInBrackets = Output;
            }

            GetExpressionWithBrackets(exprInBrackets, GetDescriptionName(func));
        }

        /// <summary>
        /// Для получения данных атрибута
        /// </summary>
        /// <param name="operatorEnum">функция</param>
        /// <returns></returns>
        private string GetDescriptionName(OperatorEnum operatorEnum)
        {
            var fieldInfo = typeof(OperatorEnum).GetField(operatorEnum.ToString());
            var description = (DescriptionAttribute) Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));

            return description.Description;
        }

        /// <summary>
        /// Для вставки локальной функции в вычисляемое выражение
        /// </summary>
        /// <param name="expr">вычисляемое выражение</param>
        /// <param name="func">функция</param>
        private void GetExpressionWithBrackets(string expr, string func)
        {
            if (Expression.Length > 0 && Expression[Expression.Length - 1] == ')')
            {
                Expression = Expression.Replace(expr, "(" + func + "(" + expr + ")" + ")");
            }
            else
            {
                Expression += "(" + func + "(" + expr + ")" + ")";
            }
        }

        /// <summary>
        /// Для получения выражения без скобок
        /// </summary>
        /// <param name="expression">вычисляемое выражение</param>
        /// <returns></returns>
        private string GetExpressionWithoutBrackets(string expression)
        {
            var indexof = expression.IndexOf("(", StringComparison.Ordinal);
            var lastindexof = expression.LastIndexOf(")", StringComparison.Ordinal);

            return expression.Substring(++indexof, lastindexof - indexof);
        }

        private bool _flagOperaion;

        private void AddButton_Click(object sender, EventArgs e)
        {
            SetOperationSymbol(GetOperationSymbol(OperatorEnum.Additional));

            PressCommand(OperatorEnum.Additional);
        }

        private void SubButton_Click(object sender, EventArgs e)
        {
            SetOperationSymbol(GetOperationSymbol(OperatorEnum.Substraction));

            PressCommand(OperatorEnum.Substraction);
        }

        private void MultButton_Click(object sender, EventArgs e)
        {
            SetOperationSymbol(GetOperationSymbol(OperatorEnum.Multiplication));

            PressCommand(OperatorEnum.Multiplication);
        }

        private void DivButton_Click(object sender, EventArgs e)
        {
            SetOperationSymbol(GetOperationSymbol(OperatorEnum.Division));

            PressCommand(OperatorEnum.Division);
        }

        private void LnButton_Click(object sender, EventArgs e)
        {
            GetExpressionLocalFunctions(OperatorEnum.Ln);

            PressCommand(OperatorEnum.Ln);
        }

        private void XPowerYButton_Click(object sender, EventArgs e)
        {
            SetOperationSymbol(GetOperationSymbol(OperatorEnum.XPowerY));

            PressCommand(OperatorEnum.XPowerY);
        }

        private void SinButton_Click(object sender, EventArgs e)
        {
            GetExpressionLocalFunctions(OperatorEnum.Sin);

            PressCommand(OperatorEnum.Sin);
        }

        private void CosButton_Click(object sender, EventArgs e)
        {
            GetExpressionLocalFunctions(OperatorEnum.Cos);

            PressCommand(OperatorEnum.Cos);
        }

        private void TanButton_Click(object sender, EventArgs e)
        {
            GetExpressionLocalFunctions(OperatorEnum.Tan);

            PressCommand(OperatorEnum.Tan);
        }

        private void ArctgButton_Click(object sender, EventArgs e)
        {
            GetExpressionLocalFunctions(OperatorEnum.Arctg);

            PressCommand(OperatorEnum.Arctg);
        }

        private void LogButton_Click(object sender, EventArgs e)
        {
            GetExpressionLocalFunctions(OperatorEnum.Log);

            PressCommand(OperatorEnum.Log);
        }

        private void ExpButton_Click(object sender, EventArgs e)
        {
            GetExpressionLocalFunctions(OperatorEnum.Exp);

            PressCommand(OperatorEnum.Exp);
        }

        private void FactButton_Click(object sender, EventArgs e)
        {
            GetExpressionLocalFunctions(OperatorEnum.Fact);

            PressCommand(OperatorEnum.Fact);
        }

        private void XPower2Button_Click(object sender, EventArgs e)
        {
            GetExpressionLocalFunctions(OperatorEnum.Sqr);

            PressCommand(OperatorEnum.Sqr);
        }

        private void btnRoot_Click(object sender, EventArgs e)
        {
            GetExpressionLocalFunctions(OperatorEnum.Sqrt);

            PressCommand(OperatorEnum.Sqrt);
        }

        private void DivOneOnXButton_Click(object sender, EventArgs e)
        {
            GetExpressionLocalFunctions(OperatorEnum.OneDivX);

            PressCommand(OperatorEnum.OneDivX);
        }

        private void VirguleButton_Click(object sender, EventArgs e)
        {
            if (Output == "NaN")
            {
                return;
            }

            if (Output.Contains(","))
            {
                return;
            }

            Output = string.Concat(Output, ",");

            _flagPressDigit = true;
        }

        private void btnAddAndSub_Click(object sender, EventArgs e)
        {
            if (Output == "NaN")
            {
                return;
            }

            var outputValue = decimal.Parse(Output);

            Output = Convert.ToString(-1 * outputValue, CultureInfo.InvariantCulture).Replace(".", ",");

            _flagOperaion = true;
        }

        private int _countLeftBrackets;

        private void btnLeftBracket_Click(object sender, EventArgs e)
        {
            if (Output == "NaN")
            {
                return;
            }

            ++_countLeftBrackets;

            lblCountBrackets.Text = _countLeftBrackets.ToString();

            Expression += "(";
        }

        private void btnRightBracket_Click(object sender, EventArgs e)
        {
            if (Output == "NaN")
            {
                return;
            }

            if (_countLeftBrackets <= 0)
            {
                return;
            }

            _flagOperaion = true;
            _flagPressDigit = false;

            --_countLeftBrackets;

            lblCountBrackets.Text = _countLeftBrackets.ToString();

            if (Expression[Expression.Length - 1] == ')')
            {
                Expression += ")";
            }
            else
            {
                Expression += GetNegativeValueInBrackets(Output, true);
            }

            var temp = Expression;
            Expression = GetExpressionInBrackets(Expression);

            PressCommand(OperatorEnum.RightBracket);

            Expression = temp;
        }


        private bool _flagEnterShift;

        private readonly Dictionary<Keys, Keys> _numbersNumm = new Dictionary<Keys, Keys>();

        private void InitializeDyctNummBumbers()
        {
            _numbersNumm.Add(Keys.NumPad0, Keys.D0);
            _numbersNumm.Add(Keys.NumPad1, Keys.D1);
            _numbersNumm.Add(Keys.NumPad2, Keys.D2);
            _numbersNumm.Add(Keys.NumPad3, Keys.D3);
            _numbersNumm.Add(Keys.NumPad4, Keys.D4);
            _numbersNumm.Add(Keys.NumPad5, Keys.D5);
            _numbersNumm.Add(Keys.NumPad6, Keys.D6);
            _numbersNumm.Add(Keys.NumPad7, Keys.D7);
            _numbersNumm.Add(Keys.NumPad8, Keys.D8);
            _numbersNumm.Add(Keys.NumPad9, Keys.D9);
        }

        private void MainFormCalculator_KeyDown(object sender, KeyEventArgs e)
        {
            Keys[] numbersArgs =
            {
                Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9,
                Keys.NumPad0, Keys.NumPad1, Keys.NumPad2, Keys.NumPad3, Keys.NumPad4, Keys.NumPad5, Keys.NumPad6,
                Keys.NumPad7, Keys.NumPad8, Keys.NumPad9
            };

            if (!_flagEnterShift && numbersArgs.Contains(e.KeyCode))
            {
                PressDigitKey(this, e);
            }

            switch (e.KeyCode)
            {
                case Keys.Back: btnClearSymbol.PerformClick(); break;
                case Keys.Escape: btnClear.PerformClick();     break;
                case Keys.Subtract: btnSub.PerformClick(); break;   
                case Keys.Add: btnAdd.PerformClick(); break;
                case Keys.Multiply: btnMult.PerformClick(); break;          
                case Keys.Divide: btnDiv.PerformClick(); break;
                case Keys.Decimal: btnVirgule.PerformClick(); break;
            }

            if (e.KeyCode == Keys.ShiftKey)
            {
                _flagEnterShift = true;
            }

            if (_flagEnterShift && e.KeyCode == Keys.D9)
            {
                btnLeftBracket.PerformClick();
            }

            if (_flagEnterShift && e.KeyCode == Keys.D0)
            {
                btnRightBracket.PerformClick();
            }

            if (_flagEnterShift && e.KeyCode == Keys.OemQuestion)
            {
                btnVirgule.PerformClick();
            }

            if (e.KeyCode == Keys.Oemplus)
            {
                btnResult.PerformClick();
            }
        }

        private void MainFormCalculator_KeyUp(object sender, KeyEventArgs e)
        {
            _flagEnterShift = false;
        }

        /// <summary>
        /// Алгоритм для выделения выражения в скобках
        /// </summary>
        /// <param name="expression">обрабатываемое выражение</param>
        /// <returns></returns>
        private string GetExpressionInBrackets(string expression)
        {
            var indexof = 0;
            var indexesLeftBrackets = new List<int>();

            indexof = expression.IndexOf(")", indexof, StringComparison.Ordinal);

            if (indexof == -1)
            {
                return null;
            }

            var lastindexof = indexof;
            lastindexof = expression.LastIndexOf("(", lastindexof, StringComparison.Ordinal);

            var substring = expression.Substring(lastindexof, indexof - lastindexof + 1);

            indexesLeftBrackets.Add(lastindexof);

            while (indexof != expression.Length - 1)
            {
                indexof = expression.IndexOf(")", indexof + 1, StringComparison.Ordinal);
                lastindexof = indexof;

                for (int i = 0; i < indexesLeftBrackets.Count; i++)
                {
                    lastindexof = expression.LastIndexOf("(", lastindexof, StringComparison.Ordinal);

                    if (indexesLeftBrackets.Contains(lastindexof))
                    {
                        lastindexof--;
                    }
                }

                lastindexof = expression.LastIndexOf("(", lastindexof, StringComparison.Ordinal);
                indexesLeftBrackets.Add(lastindexof);

                substring = expression.Substring(lastindexof, indexof - lastindexof + 1);
            }

            return substring;
        }

        private string _memoryNumber;

        private void btnSaveMem_Click(object sender, EventArgs e)
        {
            if (Output == "NaN")
            {
                return;
            }

            _memoryNumber = Output;
            lblMemoryValue.Text = _memoryNumber;
        }

        private void btnMemClear_Click(object sender, EventArgs e)
        {
            if (Output == "NaN")
            {
                return;
            }

            lblMemoryValue.Text = _memoryNumber;
        }

        private void btnMemRet_Click(object sender, EventArgs e)
        {
            if (Output == "NaN")
            {
                return;
            }

            Output = _memoryNumber;
            _flagPressDigit = true;
            _flagOperaion = true;
        }

        private void btnAddMemValue_Click(object sender, EventArgs e)
        {
            if (Output == "NaN")
            {
                return;
            }

            var memory = Convert.ToDecimal(_memoryNumber);
            var output = Convert.ToDecimal(Output);

            _memoryNumber = Convert.ToString(memory + output, CultureInfo.InvariantCulture);
            lblMemoryValue.Text = _memoryNumber;
        }

        private void btnSubMemValue_Click(object sender, EventArgs e)
        {
            if (Output == "NaN")
            {
                return;
            }

            var memory = Convert.ToDecimal(_memoryNumber);
            var output = Convert.ToDecimal(Output);

            _memoryNumber = Convert.ToString(memory - output, CultureInfo.InvariantCulture);
            lblMemoryValue.Text = _memoryNumber;
        }
    }
}
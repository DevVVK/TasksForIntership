using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Calculator.Enumerables;
using Calculator.Model;

namespace Calculator.Interface
{
    internal class PresenterCalculator
    {
        private readonly ModelCalculator _modelCalculator;

        private readonly IViewCalculator _viewCalculator;

        public PresenterCalculator(ModelCalculator modelCalculator, IViewCalculator viewCalculator)
        {
            _modelCalculator = modelCalculator;

            _viewCalculator = viewCalculator;

            _viewCalculator.CommandPressed += _viewCalculator_CommandPressed;

            InitializeHandlers();
        }

        private readonly Dictionary<OperatorEnum, Action> _actionHandlers = new Dictionary<OperatorEnum, Action>();

        private void InitializeHandlers()
        {
            _actionHandlers.Add(OperatorEnum.Result, ResultHandler);
            _actionHandlers.Add(OperatorEnum.RightBracket, RightBracketHandler);
            _actionHandlers.Add(OperatorEnum.Ln, LnHandler);
            _actionHandlers.Add(OperatorEnum.Sqr, XPower2Handler);
            _actionHandlers.Add(OperatorEnum.Sin, SinHandler);
            _actionHandlers.Add(OperatorEnum.Cos, CosHandler);
            _actionHandlers.Add(OperatorEnum.Arctg, ArctanHandler);
            _actionHandlers.Add(OperatorEnum.Exp, ExpHandler);
            _actionHandlers.Add(OperatorEnum.Log, LogHandler);
            _actionHandlers.Add(OperatorEnum.Tan, TanHandler);
            _actionHandlers.Add(OperatorEnum.Fact, FactHandler);
            _actionHandlers.Add(OperatorEnum.Sqrt, SqrtHandler);
            _actionHandlers.Add(OperatorEnum.OneDivX, OneDivX);
        }

        private string _tempVariableForResutl;

        /// <summary>
        /// Обработчик получения результата
        /// </summary>
        private void ResultHandler()
        {
            string expression;
            string expr;

            var outp = GetExpressionReplaceVirgileToPoint(_viewCalculator.Output);
            
            if (_viewCalculator.Expression.Length > 0)
            {
                _tempVariableForResutl = _viewCalculator.Expression[_viewCalculator.Expression.Length - 2]
                                            + _viewCalculator.Output;
                if (_viewCalculator.Expression[_viewCalculator.Expression.Length - 1] == ')')
                {
                    _tempVariableForResutl = null;
                }

                expr = GetExpressionReplaceVirgileToPoint(_viewCalculator.Expression);

                if (_viewCalculator.Expression.Length > 0 &&
                    _viewCalculator.Expression[_viewCalculator.Expression.Length - 1] == ')')
                {
                    expression = GetExpressionWithBrackets(expr);
                }
                else
                {
                    expression = GetExpressionWithBrackets(expr + outp);
                }
            }
            else
            {
                expression = GetExpressionWithBrackets(outp + _tempVariableForResutl);
            }

            GetResult(expression);
        }

        /// <summary>
        /// Получение результата при нажатии закрывающей скобки
        /// </summary>
        private void RightBracketHandler()
        {
            var expr = GetExpressionReplaceVirgileToPoint(_viewCalculator.Expression);
            var expression = GetExpressionWithBrackets(expr);

            GetResult(expression);
        }

        /// <summary>
        /// Получение результата при первом нажатии кнопки равно 
        /// </summary>
        private void GetResultFirstEnter()
        {
            var expr = GetDelLastSymbol(_viewCalculator.Expression);
            var expression = GetExpressionWithBrackets(expr);

            GetResult(expression);
        }

        /// <summary>
        /// Получение результата при нажатии кнопки 1/х
        /// </summary>
        private void OneDivX()
        {
            GetResult(_viewCalculator.Expression);
        }

        /// <summary>
        /// Получение результата при нажатии кнопки n!
        /// </summary>
        private void FactHandler()
        {
            GetResult(_viewCalculator.Expression);
        }

        /// <summary>
        /// Получение результата при нажатии кнопки Ln
        /// </summary>
        private void LnHandler()
        {
            GetResult(_viewCalculator.Expression);
        }

        /// <summary>
        /// Получение результата при нажатии кнопки log
        /// </summary>
        private void LogHandler()
        {
            GetResult(_viewCalculator.Expression);
        }

        /// <summary>
        /// Получение результата при нажатии кнопки sin
        /// </summary>
        private void SinHandler()
        {
            GetResult(_viewCalculator.Expression);
        }

        /// <summary>
        /// Получение результата при нажатии кнопки cos
        /// </summary>
        private void CosHandler()
        {
            GetResult(_viewCalculator.Expression);
        }

        /// <summary>
        /// Получение результата при нажатии кнопки tan
        /// </summary>
        private void TanHandler()
        {
            GetResult(_viewCalculator.Expression);
        }

        /// <summary>
        /// Получение результата при нажатии кнопки arctan
        /// </summary>
        private void ArctanHandler()
        {
            GetResult(_viewCalculator.Expression);
        }

        /// <summary>
        /// Получение результата при нажатии кнопки exp
        /// </summary>
        private void ExpHandler()
        {
            GetResult(_viewCalculator.Expression);
        }

        /// <summary>
        /// Получение результата при нажатии кнопки x^2
        /// </summary>
        private void XPower2Handler()
        {
            GetResult(_viewCalculator.Expression);
        }

        /// <summary>
        /// Получение результата при нажатии кнопки вычисления корня квадратного
        /// </summary>
        private void SqrtHandler()
        {
            GetResult(_viewCalculator.Expression);
        }

        /// <summary>
        /// обработчик события нажатия кнопки
        /// </summary>
        /// <param name="sender">экземпляр вызывающий событие</param>
        /// <param name="e">операция</param>
        private void _viewCalculator_CommandPressed(object sender, CommandPressedEventArgs e)
        {
            if (_actionHandlers.ContainsKey(e.Command))
            {
                _actionHandlers[e.Command]?.Invoke();
            }
            else
            {
                GetResultFirstEnter();
            }
        }

        /// <summary>
        /// Для получения результата
        /// </summary>
        /// <param name="expr">Вычисляемое выражение</param>
        private void GetResult(string expr)
        {
            decimal result = 0;

            try
            {
                result = _modelCalculator.SetStringParse(expr);
            }
            catch (Exception)
            {
                _viewCalculator.Output = "NaN";
                return;
            }

            if (!GetConvertNumberToString(result).Contains("."))
            {
                _viewCalculator.Output = GetConvertNumberToString(result);
            }
            else
            {
                _viewCalculator.Output = GetExpressionWithoutZero(result);
            }
        }

        /// <summary>
        /// Для замены запятой, точкой
        /// </summary>
        /// <param name="expr">результат</param>
        /// <returns></returns>
        private string GetExpressionReplaceVirgileToPoint(string expr)
        {
            return expr.Replace(",", ".");
        }

        /// <summary>
        /// Для замены точки, запятой
        /// </summary>
        /// <param name="expr"></param>
        /// <returns></returns>
        private string GetExpressionReplacePointToVirgile(string expr)
        {
            return expr.Replace(".", ",");
        }

        /// <summary>
        /// В случае неполного выражения удаляется символ операции
        /// </summary>
        /// <param name="expr">вычисляемое выражение</param>
        /// <returns></returns>
        private string GetDelLastSymbol(string expr)
        {
            return GetExpressionReplaceVirgileToPoint(expr.Remove(expr.Length - 3));
        }

        /// <summary>
        /// Конвертирует из decimal в string
        /// </summary>
        /// <param name="expr">конвертируемое число</param>
        /// <returns></returns>
        private string GetConvertNumberToString(decimal expr)
        {
            return Convert.ToString(expr, CultureInfo.GetCultureInfo("en-US"));
        }

        /// <summary>
        /// Удаление 0 и , d в случае если результат предстваляет челое число 
        /// </summary>
        /// <param name="number">результат</param>
        /// <returns></returns>
        private string GetExpressionWithoutZero(decimal number)
        {
            return GetConvertNumberToString(number).TrimEnd('0').TrimEnd(',');
        }

        /// <summary>
        /// Посчитвание количества открывающих скобок
        /// </summary>
        /// <param name="expr">вычисляемое выражение</param>
        /// <returns></returns>
        private int GetCountExpressionLeftBrackets(string expr)
        {
            return expr.Count(symbol => symbol == '(');
        }

        /// <summary>
        /// Подсчитываение количества закрывающих скобок
        /// </summary>
        /// <param name="expr">вычисляемое выражение</param>
        /// <returns></returns>
        private int GetCountExpressionRightBrackets(string expr)
        {
            return expr.Count(symbol => symbol == ')');
        }

        /// <summary>
        /// Добавляет закрывающие скобки в случаче нехватки
        /// </summary>
        /// <param name="expr">вычисляемое выражение</param>
        /// <returns></returns>
        private string GetExpressionWithBrackets(string expr)
        {
            var countLeftBrackets = GetCountExpressionLeftBrackets(expr);
            var countRightBrackets = GetCountExpressionRightBrackets(expr);

            if (countLeftBrackets == countRightBrackets)
            {
                return expr;
            }

            for (var i = 0; i < countLeftBrackets - countRightBrackets; i++)
            {
                expr += ")";
            }

            return expr;
        }
    }
}

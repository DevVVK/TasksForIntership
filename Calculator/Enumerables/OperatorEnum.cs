using System.ComponentModel;

namespace Calculator.Enumerables
{
    /// <summary>
    /// Перечисление описывающее команды для вычислений
    /// </summary>
    public enum OperatorEnum
    {
        // основные операции
        [Description(" + ")]
        Additional,

        [Description(" * ")]
        Multiplication,

        [Description(" - ")]
        Substraction,

        [Description(" / ")]
        Division,

        //Возведение в степень
        [Description(" ^ ")]
        XPowerY,

        // тригонометрические функции
        [Description("sin")]
        Sin,

        [Description("cos")]
        Cos,

        [Description("tan")]
        Tan,

        [Description("ctan")]
        Ctg,

        [Description("arctan")]
        Arctg,

        // логарифмы
        [Description("ln")]
        Ln,

        [Description("log")]
        Log,

        // экспанента
        [Description("exp")]
        Exp,

        // факториал
        [Description("fact")]
        Fact,

        //результат 
        [Description("result")]
        Result,

        // возвести в степень 2 
        [Description("sqr")]
        Sqr,

        //извлечение корня квадратного
        [Description("sqrt")]
        Sqrt,

        // 1/x 
        [Description("reciproc")]
        OneDivX,

        // Операция добавления правой скобки
        RightBracket
    }
}
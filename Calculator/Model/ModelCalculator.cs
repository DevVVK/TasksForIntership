using System;
using Mathos.Parser;

namespace Calculator.Model
{
    public class ModelCalculator
    {
        private readonly MathParser _newMathParser;

        public ModelCalculator()
        {
            _newMathParser = new MathParser();

            InitializeMathosParser();
        }

        /// <summary>
        /// Добавление в парсер недостающих функций
        /// </summary>
        private void InitializeMathosParser()
        {
            _newMathParser.LocalFunctions.Add("sqr", number => (decimal)Math.Pow((double)number[0], 2.0));

            _newMathParser.LocalFunctions.Add("reciproc", number => (decimal)1.0 / number[0]);

            _newMathParser.LocalFunctions.Add("ln", number => (decimal)Math.Log10(Convert.ToDouble(number)));

            _newMathParser.LocalFunctions.Add("fact", number =>
            {
                decimal factorial = 1;

                if (number[0] == 0)
                {
                    return factorial;
                }

                for (var i = 2; i <= number[0]; i++)
                {
                    factorial *= i;
                }

                return factorial;
            });
        }

        /// <summary>
        /// Парсинг и вычисление выражения
        /// </summary>
        /// <param name="parse"></param>
        /// <returns></returns>
        public decimal SetStringParse(string parse) => _newMathParser.Parse(parse);
    }
}
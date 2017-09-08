using System;
using System.Windows.Forms;
using Calculator.Interface;
using Calculator.View;
using Calculator.Model;

namespace Calculator
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var formCalcelator = new MainFormCalculator();
            var modelCalculator = new ModelCalculator();
            var viewPresenter = new PresenterCalculator(modelCalculator, formCalcelator);

            Application.Run(formCalcelator);
        }
    }
}

using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Emulator.Factories
{
    /// <summary>
    /// Класс представляющий инициализатор робота
    /// </summary>
    public class RobotInitializer
    {
        /// <summary>
        /// Метод создающий объект - робот, для последующего исполнения команд
        /// </summary>
        /// <param name="color">цвет робота</param>
        /// <returns></returns>
        public Path CreateRobot(Color color)
        {
            var robot = new Path
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Fill = new SolidColorBrush(color),
            };

            return robot;
        }
    }
}
using System.Collections.Generic;
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
        /// <param name="size">размер робота</param>
        /// <param name="color">цвет робота</param>
        /// <returns></returns>
        public Path CreateRobot(int size, Color color)
        {
            var realSize = size - 10;

            var robot = new Path
            {
                Width = realSize,
                Height = realSize,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Fill = new SolidColorBrush(color),
                Data = CreateDataFigure(realSize)
            };

            return robot;
        }

        /// <summary>
        /// Метод рисует робота
        /// </summary>
        /// <returns></returns>
        private static PathGeometry CreateDataFigure(int size)
        {
            var segments = new List<PathSegment>
            {
                new LineSegment(new Point(size / 4, 0), true),
                new LineSegment(new Point(size, size / 2), true),
                new LineSegment(new Point(size / 4, size), true)
            };

            var figure = new PathFigure(new Point(0, size / 2), segments, true);

            return new PathGeometry(new List<PathFigure>{ figure });
        }
    }
}
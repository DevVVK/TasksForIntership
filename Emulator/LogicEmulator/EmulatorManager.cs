using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Emulator.LogicEmulator;
using RobotObjects.Enumerables;
using Grid = System.Windows.Controls.Grid;

namespace Emulator.Factories
{
    /// <summary>
    /// Класс представляющий инициализатор сетки
    /// </summary>
    public class EmulatorManager
    {
        /// <summary>
        /// Визуальная сетка
        /// </summary>
        private readonly ViewGrid grid;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="grid">сетка, которую нужно заполнить ячейками</param>
        /// <param name="cells">ячейки сетки</param>
        /// <param name="rowCount">количество строк в сетке</param>
        /// <param name="columnCount">количество столбцов в сетке</param>
        public EmulatorManager(ViewGrid grid)
        {
            this.grid = grid;
        }

        /// <summary>
        /// Метод добавляющий робота в с сетку
        /// </summary>
        /// <param name="robot">Робот. объект типа <see cref="Path"/></param>
        /// <param name="rowPoint">индекс строки нахождения робота</param>
        /// <param name="columnPoint">индекс столбца нахождения робота</param>
        public void AddRobot(Path robot, int rowPoint, int columnPoint)
        {
            robot.Data = CreateDataFigure(grid.VisualCells[rowPoint, columnPoint].Width);

            Grid.SetRow(robot, rowPoint);
            Grid.SetColumn(robot, columnPoint);

            grid.VisualGrid.Children.Add(robot);
        }

        /// <summary>
        /// Метод двигающий робота местоположением робота
        /// </summary>
        /// <param name="robot">робот</param>
        /// <param name="rowPoint">строка, в которую нужно переместить робота</param>
        /// <param name="columnPoint">столбец, в который нужно переместить робота</param>
        public void UpdatePointRobot(Path robot, int rowPoint, int columnPoint)
        {
            Grid.SetRow(robot, rowPoint);
            Grid.SetColumn(robot, columnPoint);
        }

        /// <summary>
        /// Метод закрашивающий выбранным цветом ячейку
        /// </summary>
        /// <param name="row">индекс строки ячейки</param>
        /// <param name="column">индекс столбца ячейки</param>
        /// <param name="color">цвет заливки</param>
        public void UpdateColorCell(ColorCell color, int row, int column)
        {
            switch (color)
            {
                case ColorCell.Black:
                    grid.VisualCells[row, column].Fill = new SolidColorBrush { Color = Colors.Black };
                    break;

                case ColorCell.White:
                    grid.VisualCells[row, column].Fill = new SolidColorBrush { Color = Colors.White };
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(color), color, null);
            }
        }

        /// <summary>
        /// Метод поворачивающий визуального робота в указанном направлении
        /// </summary>
        /// <param name="robot">робот, которого нужно повернуть</param>
        /// <param name="route">направление поворота</param>
        public void RotationRobot(Path robot, RouteMove route)
        {
            switch (route)
            {
                case RouteMove.Right: Rotate(robot, 0); break;
                case RouteMove.Bottom: Rotate(robot, 90); break;
                case RouteMove.Left: Rotate(robot, 180); break;
                case RouteMove.Top: Rotate(robot, 270); break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(route), route, null);
            }
        }

        /// <summary>
        /// Метод поворачивающий визуального робота
        /// </summary>
        /// <param name="robot"></param>
        /// <param name="angle"></param>
        private void Rotate(Path robot, double angle)
        {
            var rotation = new RotateTransform();
            var center = new Point(0.5, 0.5);

            robot.RenderTransformOrigin = center;
            rotation.Angle = angle;
            robot.RenderTransform = rotation;
        }

        /// <summary>
        /// Метод рисующий робота по заданному размеру
        /// </summary>
        /// <returns></returns>
        private PathGeometry CreateDataFigure(double size)
        {
            var realSize = size - size / 10;

            var segments = new List<PathSegment>
            {
                new LineSegment(new Point(realSize / 4, 0), true),
                new LineSegment(new Point(realSize, realSize / 2), true),
                new LineSegment(new Point(realSize / 4, realSize), true)
            };

            var figure = new PathFigure(new Point(realSize / 2, realSize / 2), segments, true);

            return new PathGeometry(new List<PathFigure> { figure });
        }
    }
}
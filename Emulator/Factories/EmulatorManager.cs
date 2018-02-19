using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using RobotObjects.Enumerables;
using RobotObjects.Objects;
using Grid = System.Windows.Controls.Grid;

namespace Emulator.Factories
{
    /// <summary>
    /// Класс представляющий инициализатор сетки
    /// </summary>
    public class EmulatorManager
    {
        #region Закрытые поля 

        /// <summary>
        /// Сетка, которую нужно заполнить ячейками 
        /// </summary>
        private readonly Grid _grid;

        /// <summary>
        /// Ячейки сетки
        /// </summary>
        private readonly Cell[,] _cells;

        /// <summary>
        /// Отображаемые ячейки
        /// </summary>
        private readonly Rectangle[,] _visibleCells;

        /// <summary>
        /// Размер ячейки
        /// </summary>
        private readonly double _cellSize;

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="grid">сетка, которую нужно заполнить ячейками</param>
        /// <param name="cells">ячейки сетки</param>
        /// <param name="rowCount">количество строк в сетке</param>
        /// <param name="columnCount">количество столбцов в сетке</param>
        public EmulatorManager(Grid grid, Cell[,] cells, int rowCount, int columnCount)
        {
            _grid = grid;
            _cells = cells;
            _visibleCells = new Rectangle[rowCount, columnCount];
            _cellSize = _grid.MinWidth / columnCount;

            InitializeGrid(rowCount, columnCount);
        }

        #endregion

        #region Открытые методы

        /// <summary>
        /// Метод добавляющий робота в с сетку
        /// </summary>
        /// <param name="robot">Робот. объект типа <see cref="Path"/></param>
        /// <param name="rowPoint">индекс строки нахождения робота</param>
        /// <param name="columnPoint">индекс столбца нахождения робота</param>
        public void AddRobot(Path robot, int rowPoint, int columnPoint)
        {
            robot.Data = CreateDataFigure(_visibleCells[rowPoint, columnPoint].Width);

            Grid.SetRow(robot, rowPoint);
            Grid.SetColumn(robot, columnPoint);

            _grid.Children.Add(robot);
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
                    _visibleCells[row, column].Fill = new SolidColorBrush { Color = Colors.Black };
                    break;

                case ColorCell.White:
                    _visibleCells[row, column].Fill = new SolidColorBrush { Color = Colors.White };
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
            RotateTransform rotation = new RotateTransform();
            Point center = new Point(0.5,0.5);

            switch (route)
            {
                case RouteMove.Right:
                    robot.RenderTransformOrigin = center;
                    rotation.Angle = 0;
                    robot.RenderTransform = rotation;
                    break;
                case RouteMove.Left:
                    robot.RenderTransformOrigin = center;
                    rotation.Angle = 180;
                    robot.RenderTransform = rotation;
                    break;
                case RouteMove.Top:
                    robot.RenderTransformOrigin = center;
                    rotation.Angle = 270;
                    robot.RenderTransform = rotation;
                    break;
                case RouteMove.Bottom:
                    robot.RenderTransformOrigin = center;
                    rotation.Angle = 90;
                    robot.RenderTransform = rotation;
                    break;
            }
        }

        #endregion

        #region Закрытые методы

        /// <summary>
        ///  Методы заполняющий сетку ячейками
        /// </summary>
        /// <param name="rowCount">количество строк в сетке</param>
        /// <param name="columnCount">количество столбцов в сетке</param>
        private void InitializeGrid(int rowCount, int columnCount)
        {
            _grid.Children.Clear();

            for (var row = 0; row < rowCount; row++)
            {
                for (var column = 0; column < columnCount; column++)
                {
                    switch (_cells[row, column].Color)
                    {
                        case ColorCell.Black:
                            AddCellInGrid(Colors.Black, row, column);
                            break;
                        case ColorCell.White:
                            AddCellInGrid(Colors.White, row, column);
                            break;

                        default: throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }

        /// <summary>
        /// Добавляет ячейку в сетку
        /// </summary>
        /// <param name="color">цвет ячейки</param>
        /// <param name="row">строка</param>
        /// <param name="column">столбец</param>
        private void AddCellInGrid(Color color, int row, int column)
        {
            var cell = CreateRectangle(color);

            var rowDef = new RowDefinition { Height = GridLength.Auto };
            var colDef = new ColumnDefinition { Width = GridLength.Auto };

            _grid.RowDefinitions.Add(rowDef);
            _grid.ColumnDefinitions.Add(colDef);

            Grid.SetRow(cell, row);
            Grid.SetColumn(cell, column);

            _grid.Children.Add(cell);
            _visibleCells[row, column] = cell;
        }

        /// <summary>
        /// Создает ячейку
        /// </summary>
        /// <param name="color">цвет ячейки</param>
        /// <returns></returns>
        private Rectangle CreateRectangle(Color color)
        {
            var cell = new Rectangle
            {
                Width = _cellSize,
                Height = _cellSize,
                Fill = new SolidColorBrush(color),
                Margin = new Thickness(0.5),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            return cell;
        }

        /// <summary>
        /// Метод рисующий робота по заданному размеру
        /// </summary>
        /// <returns></returns>
        private static PathGeometry CreateDataFigure(double size)
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

        #endregion
    }
}
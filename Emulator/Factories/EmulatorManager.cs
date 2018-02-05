using System;
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
        /// Количество строк в сетке 
        /// </summary>
        private readonly int _rowCount;

        /// <summary>
        /// Количество стволбцов в сетке
        /// </summary>
        private readonly int _columnCount;

        /// <summary>
        /// Отображаемые ячейки
        /// </summary>
        private readonly Rectangle[,] _visibleCells;

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="grid">сетка, которую нужно заполнить ячейками</param>
        /// <param name="cells">ячейки сетки</param>
        /// <param name="rowCount">количество строк в сетке</param>
        /// <param name="columnCount">количество столбцов в сетке</param>
        /// <param name="rowPoint">индекс строки нахождения робота</param>
        /// <param name="columnPoint">индкс столбца нахождения робота</param>
        public EmulatorManager(Grid grid, Cell[,] cells, int rowCount, int columnCount)
        {
            _grid = grid;
            _cells = cells;
            _rowCount = rowCount;
            _columnCount = columnCount;
            _visibleCells = new Rectangle[rowCount, columnCount];

            InitializeGrid();
        }

        #endregion

        #region Открытые методы

        /// <summary>
        /// Методы заполняющий сетку ячейками
        /// </summary>
        private void InitializeGrid()
        {
            for (var row = 0; row < _rowCount; row++)
            {
                for (var column = 0; column < _columnCount; column++)
                {
                    Rectangle cell = null;
                    RowDefinition rowDef = new RowDefinition{Height = GridLength.Auto};
                    ColumnDefinition colDef = new ColumnDefinition{Width = GridLength.Auto};

                    switch (_cells[row, column].Color)
                    {
                        case ColorCell.Black:
                            cell = CreateRectangle(new SolidColorBrush {Color = Colors.Black});
                            break;

                        case ColorCell.White:
                            cell = CreateRectangle(new SolidColorBrush {Color = Colors.White});
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    _grid.RowDefinitions.Add(rowDef);
                    _grid.ColumnDefinitions.Add(colDef);

                    Grid.SetRow(cell, row);
                    Grid.SetColumn(cell, column);

                    _visibleCells[row, column] = cell;
                    _grid.Children.Add(cell);
                }
            }
        }

        /// <summary>
        /// Метод добавляющий робота в с сетку
        /// </summary>
        /// <param name="robot">Робот. объект типа <see cref="Path"/></param>
        /// <param name="rowPoint">индекс строки нахождения робота</param>
        /// <param name="columnPoint">индекс столбца нахождения робота</param>
        public void AddRobot(Path robot, int rowPoint, int columnPoint)
        {
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
                    _visibleCells[row, column].Fill = new SolidColorBrush{ Color = Colors.Black };
                    break;

                case ColorCell.White:
                    _visibleCells[row, column].Fill = new SolidColorBrush { Color = Colors.Black };
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(color), color, null);
            }
        }

        //TODO : реализовать метод поворота робота
        /// <summary>
        /// Метод поворачивающий визуального робота в указанном направлении
        /// </summary>
        /// <param name="robot">робот, которого нужно повернуть</param>
        /// <param name="route">направление поворота</param>
        public void RotationRobot(Path robot, RouteMove route)
        {
           /* var rotateTransform = robot.RenderTransform as RotateTransform;

            if (rotateTransform != null)
            {
                rotateTransform.CenterX = robot.Width / 2;
                rotateTransform.CenterY = robot.Height / 2;

                switch (route)
                {

                }
            }*/
        }
        
        #endregion

        #region Закрытые методы

        /// <summary>
        /// Создает ячейку
        /// </summary>
        /// <param name="fill">цвет ячейки</param>
        /// <returns></returns>
        private Rectangle CreateRectangle(SolidColorBrush fill)
        {
            var size = _grid.Width / _columnCount;

            return new Rectangle
            {
                Width = size,
                Height = size,
                Fill = fill,
                Margin = new Thickness(0.2),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
        }

        #endregion
    }
}
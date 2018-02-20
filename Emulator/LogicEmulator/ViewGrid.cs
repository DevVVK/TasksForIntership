using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using RobotObjects.Enumerables;
using Grid = RobotObjects.Objects.Grid;

namespace Emulator.LogicEmulator
{
    public class ViewGrid
    {
        /// <summary>
        /// Ячейки сетки
        /// </summary>
        public Rectangle[,] VisualCells { get; }
        
        /// <summary>
        /// Абстрактная сетка
        /// </summary>
        public Grid AbstractGrid { get; }

        /// <summary>
        /// Визуальная сетка
        /// </summary>
        public System.Windows.Controls.Grid VisualGrid { get; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="visualGrid">визуальная сетка</param>
        /// <param name="abstractGrid">абстрактная сетка</param>
        public ViewGrid(System.Windows.Controls.Grid visualGrid, Grid abstractGrid)
        {
            VisualGrid = visualGrid;
            AbstractGrid = abstractGrid;
            VisualCells = new Rectangle[AbstractGrid.RowCount, AbstractGrid.ColumnCount];
            GridInit();
        }

        /// <summary>
        /// Метод инициализирующий визуальную сетку
        /// </summary>
        private void GridInit()
        {
            VisualGrid.Children.Clear();

            for (var row = 0; row < AbstractGrid.RowCount; row++)
            {
                for (var column = 0; column < AbstractGrid.ColumnCount; column++)
                {
                    switch (AbstractGrid.Cells[row, column].Color)
                    {
                        case ColorCell.Black: AddCellInGrid(Colors.Black, row, column); break;
                        case ColorCell.White: AddCellInGrid(Colors.White, row, column); break;

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

            VisualGrid.RowDefinitions.Add(rowDef);
            VisualGrid.ColumnDefinitions.Add(colDef);

            System.Windows.Controls.Grid.SetRow(cell, row);
            System.Windows.Controls.Grid.SetColumn(cell, column);

            VisualGrid.Children.Add(cell);
            VisualCells[row, column] = cell;
        }

        /// <summary>
        /// Получает размер ячейки
        /// </summary>
        /// <returns></returns>
        private Double GetSizeCell() => VisualGrid.ActualWidth / AbstractGrid.ColumnCount;

        /// <summary>
        /// Создает ячейку
        /// </summary>
        /// <param name="color">цвет ячейки</param>
        /// <returns></returns>
        private Rectangle CreateRectangle(Color color)
        {
            var cellSize = GetSizeCell();

            var cell = new Rectangle
            {
                Width = cellSize,
                Height = cellSize,
                Fill = new SolidColorBrush(color),
                Margin = new Thickness(0.5),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            return cell;
        }
    }
}
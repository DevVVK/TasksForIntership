using System;
using System.Linq;
using System.Text.RegularExpressions;
using Emulator.Models;
using RobotObjects.Enumerables;
using static Emulator.AttributeLogic.AttributeManager;

namespace Emulator.Mappers
{
    /// <summary>
    /// Класс для отображения модели <see cref="CommandModel"/> в команды робота-исполнителя
    /// </summary>
    public static class CommandModelMapper
    {
        #region Закрытые методы

        /// <summary>
        /// Метод возвращающий строку для исключения
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string GetMessage(string input) => $"Источник не является командой {input}";

        #endregion

        #region Открытые методы

        /// <summary>
        /// Метод получающий модель команды инииализации <see cref="InitializeCommandModel"/>
        /// </summary>
        /// <param name="source">источник данных <see cref="CommandModel"/></param>
        /// <returns></returns>
        public static InitializeCommandModel GetInitializeCommandModel(CommandModel source)
        {
            if (source.CommandName != GetDescription(typeof(InitializeCommandModel)))
                throw new ArgumentException(GetMessage("инициализации"));

            string[] elements = source.OneParameter.Split(',', ';', '[', ']', ' ').Where(item => Regex.IsMatch(item, $"[0-9]")).ToArray(); 

            var initializeCommandModel = new InitializeCommandModel
            {
                Id = source.CommandId,
                RowCount = Convert.ToInt32(elements[0]),
                ColumnCount = Convert.ToInt32(elements[1]),
                RowPoint = Convert.ToInt32(elements[2]),
                ColumnPoint = Convert.ToInt32(elements[3]),
                NextCommandNumber = Convert.ToInt32(source.TwoParameter)
            };

            return initializeCommandModel;
        }

        /// <summary>
        /// Метод получающий модель команды движения робота <see cref="MoveCommandModel"/>
        /// </summary>
        /// <param name="source">источник данных <see cref="CommandModel"/></param>
        /// <returns></returns>
        public static MoveCommandModel GetMoveCommandModel(CommandModel source)
        {
            if (source.CommandName != GetDescription(typeof(MoveCommandModel)))
                throw new ArgumentException(GetMessage("движения"));

            var moveCommandModel = new MoveCommandModel
            {
                Id = source.CommandId,
                CellCount = Convert.ToInt32(source.OneParameter),
                NextCommandNumber = Convert.ToInt32(source.TwoParameter)
            };

            return moveCommandModel;
        }

        /// <summary>
        /// Метод получающий модель команды поворота робота <see cref="RotationCommandModel"/>
        /// </summary>
        /// <param name="source">источник данных <see cref="RotationCommandModel"/></param>
        /// <returns></returns>
        public static RotationCommandModel GetRotationCommandModel(CommandModel source)
        {
            if (source.CommandName != GetDescription(typeof(RotationCommandModel)))
                throw new ArgumentException(GetMessage("поворота"));

            // ReSharper disable once PossibleNullReferenceException
            RouteMove route = GetValueDescriptionsFields<RouteMove>()
                .FirstOrDefault(item => item.Description == source.OneParameter).Value;

            var rotationCommandModel = new RotationCommandModel
            {
                Id = source.CommandId,
                Route = route,
                NextCommandId = Convert.ToInt32(source.TwoParameter)
            };

            return rotationCommandModel;
        }

        /// <summary>
        /// Метод получающий модель команды заливки ячейки, на которой находится робот <see cref="PouringCellCommandModel"/>
        /// </summary>
        /// <param name="source">источник данных <see cref="CommandModel"/></param>
        /// <returns></returns>
        public static PouringCellCommandModel GetPouringCommandModel(CommandModel source)
        {
            if (source.CommandName != GetDescription(typeof(PouringCellCommandModel)))
                throw new ArgumentException(GetMessage("заливки"));

            // ReSharper disable once PossibleNullReferenceException
            ColorCell color = GetValueDescriptionsFields<ColorCell>()
                .FirstOrDefault(item => item.Description == source.OneParameter).Value;

            var pouringCellCommandModel = new PouringCellCommandModel
            {
                Id = source.CommandId,
                CellColor = color,
                NextCommandId = Convert.ToInt32(source.TwoParameter)
            };

            return pouringCellCommandModel;
        }

        #endregion
    }
}
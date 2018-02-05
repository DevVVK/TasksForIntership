using Emulator.AttributeLogic;
using Emulator.Models;

namespace Emulator.Mappers
{
    /// <summary>
    /// Класс отображения данных списка команд в модели команд
    /// </summary>
    public static class ListModelMapper
    {
        #region Методы отображения моделей

        /// <summary>
        /// Метод отображения модели <see cref="InitializeCommandModel"/> в модель <see cref="CommandModel"/>
        /// </summary>
        /// <param name="source">источник данных см. <see cref="InitializeCommandModel"/></param>
        /// <returns></returns>
        public static CommandModel GetCommand(InitializeCommandModel source)
        {
            if (source == null) return null;

            var commandModel = new CommandModel
            {
                CommandId = source.Id,
                CommandName = AttributeManager.GetDescription(typeof(InitializeCommandModel)),
                OneParameter = $"[{source.RowCount};{source.ColumnCount}], [{source.RowPoint};{source.ColumnPoint}]",
                TwoParameter = source.NextCommandNumber.ToString()
            };

            return commandModel;
        }

        /// <summary>
        /// Метод отображения модели <see cref="LearnCellCommandModel"/> в модель <see cref="CommandModel"/>
        /// </summary>
        /// <param name="source">источник данных см. <see cref="LearnCellCommandModel"/></param>
        /// <returns></returns>
        public static CommandModel GetCommand(LearnCellCommandModel source)
        {
            if (source == null) return null;

            var commandModel = new CommandModel
            {
                CommandId = source.Id,
                CommandName = AttributeManager.GetDescription(typeof(LearnCellCommandModel)),
                OneParameter = source.CommandIdIfCellColorBlack.ToString(),
                TwoParameter = source.CommandIdIfCellColorWhite.ToString()
            };

            return commandModel;
        }

        /// <summary> 
        /// Метод отображения модели <see cref="MoveCommandModel"/> в молель <see cref="CommandModel"/>
        /// </summary>
        /// <param name="source">источник данных см. <see cref="MoveCommandModel"/></param>
        /// <returns></returns>
        public static CommandModel GetCommand(MoveCommandModel source)
        {
            if (source == null) return null;

            var commandModel = new CommandModel
            {
                CommandId = source.Id,
                CommandName = AttributeManager.GetDescription(typeof(MoveCommandModel)),
                OneParameter = source.CellCount.ToString(),
                TwoParameter = source.NextCommandNumber.ToString()
            };

            return commandModel;
        }

        /// <summary>
        /// Метод отображени модели <see cref="PouringCellCommandModel"/> в модель <see cref="CommandModel"/>
        /// </summary>
        /// <param name="source">источник данных см. <see cref="CommandModel"/></param>
        /// <returns></returns>
        public static CommandModel GetCommand(PouringCellCommandModel source)
        {
            if (source == null) return null;

            var commandModel = new CommandModel
            {
                CommandId = source.Id,
                CommandName = AttributeManager.GetDescription(typeof(PouringCellCommandModel)),
                OneParameter = AttributeManager.GetEnumDescriptionField(source.CellColor),
                TwoParameter = source.NextCommandId.ToString()
            };

            return commandModel;
        }

        /// <summary>
        /// Метод отображения модели <see cref="RotationCommandModel"/> в модель <see cref="CommandModel"/>
        /// </summary>
        /// <param name="source">источник данных см. <see cref="RotationCommandModel"/></param>
        /// <returns></returns>
        public static CommandModel GetCommand(RotationCommandModel source)
        {
            if (source == null) return null;

            var commandModel = new CommandModel
            {
                CommandId = source.Id,
                CommandName = AttributeManager.GetDescription(typeof(RotationCommandModel)),
                OneParameter = AttributeManager.GetEnumDescriptionField(source.Route),
                TwoParameter = source.NextCommandId.ToString()
            };

            return commandModel;
        }

        #endregion
    }
}
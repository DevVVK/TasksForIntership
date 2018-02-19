using System;
using Emulator.Models;
using Emulator.ViewModels.Enumerables;
using RobotObjects.Enumerables;

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
        /// Метод получающий модель команды движения робота <see cref="MoveCommandModel"/>
        /// </summary>
        /// <param name="source">источник данных <see cref="CommandModel"/></param>
        /// <returns></returns>
        public static MoveCommandModel GetMoveCommandModel(CommandModel source)
        {
            if ((CommandName)source.CurrentName != CommandName.Move)
                throw new ArgumentException(GetMessage("движения"));

            var moveCommandModel = new MoveCommandModel
            {
                Id = source.CommandId,
                CellCount = source.CurrentOneParameter,
                NextCommandNumber = source.CurrentTwoParameter
            };

            return moveCommandModel;
        }

        /// <summary>
        /// Метод получающий модель команды поворота робота <see cref="RotationCommandModel"/>
        /// </summary>
        /// <param name="source">источник данных <see cref="CommandModel"/></param>
        /// <returns></returns>
        public static RotationCommandModel GetRotationCommandModel(CommandModel source)
        {
            if ((CommandName)source.CurrentName != CommandName.Rotation)
                throw new ArgumentException(GetMessage("поворота"));

            var rotationCommandModel = new RotationCommandModel
            {
                Id = source.CommandId,
                Route = (RouteMove)source.CurrentOneParameter,
                NextCommandId = source.CurrentTwoParameter
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
            if ((CommandName)source.CurrentName != CommandName.Pouring)
                throw new ArgumentException(GetMessage("заливки"));

            var pouringCellCommandModel = new PouringCellCommandModel
            {
                Id = source.CommandId,
                CellColor = (ColorCell)source.CurrentOneParameter,
                NextCommandId = source.CurrentTwoParameter
            };

            return pouringCellCommandModel;
        }
  
        /// <summary>
        /// Метод получающий модель команды изучения цвета ячейки, на которой находится робот <see cref="LearnCellCommandModel"/>
        /// </summary>
        /// <param name="source">источник данных <see cref="CommandModel"/></param>
        /// <returns></returns>
        public static LearnCellCommandModel GetLearnCellCommandModel(CommandModel source)
        {
            if ((CommandName)source.CurrentName != CommandName.Learn)
                throw new ArgumentException(GetMessage("изучения"));

            var learnCellModel = new LearnCellCommandModel
            {
                Id = source.CommandId,
                CommandIdIfCellColorBlack = source.CurrentOneParameter,
                CommandIdIfCellColorWhite = source.CurrentTwoParameter
            };

            return learnCellModel;
        }

        #endregion
    }
}
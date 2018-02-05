using System.Windows.Controls;

namespace Emulator.Invocators
{
    public class CommandInvocator
    {
        #region Закрытые поля 

        /// <summary>
        /// Отображаемая сетка
        /// </summary>
        private Grid _visibleGrid;

        #endregion

        #region Конструкторы 

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="visibleGrid">отображаемая сетка</param>
        public CommandInvocator(Grid visibleGrid)
        {
            _visibleGrid = visibleGrid;
        }

        #endregion



    }
}
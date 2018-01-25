using System.Collections.ObjectModel;
using System.Windows.Input;
using RobotObjects.Objects.Enumerables;

namespace Robot.ViewModels
{
    public class RotationViewModel
    {
        #region Открытые свойства

        /// <summary>
        /// Направление движения робота
        /// </summary>
        public RouteMove Route { get; set; }

        /// <summary>
        /// Источник для выбора направления движения робота
        /// </summary>
        public ObservableCollection<string> RouteMoveSource { get; set; }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public RotationViewModel()
        {
            
        }

        #endregion

        #region Команды 

        /// <summary>
        /// Команда поворота робота 
        /// </summary>
        public ICommand RotationCommand { get; }

        #endregion 
    }
}
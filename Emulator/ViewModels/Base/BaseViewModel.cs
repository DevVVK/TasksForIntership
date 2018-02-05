using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Emulator.ViewModels.Base
{
    /// <summary>
    /// Базовый класс модели - представления
    /// </summary>
    public class BaseViewModel: INotifyPropertyChanged, IDataErrorInfo
    {
        #region Открытые свойства

        /// <summary>
        /// Индексатор проверяющий данные на соответствие условиям (нужно переопределить)
        /// </summary>
        /// <param name="columnName">свойство, которое нужно проверить</param>
        /// <returns></returns>
        public virtual string this[string columnName] => throw new System.NotImplementedException();

        public string Error { get; } = null;
        
        #endregion

        #region События

        /// <summary>
        /// Событие изменения свойства (не реализовано так как подключена библиотека FodyPropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Методы

        /// <summary>
        /// Метод вызывающий событиие изменения свойства
        /// </summary>
        /// <param name="property">свойство, которое обновилось</param>
        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        #endregion
    }
}
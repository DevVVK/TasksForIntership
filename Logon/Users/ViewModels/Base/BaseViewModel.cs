using System.ComponentModel;

namespace Logon.Users.ViewModels.Base
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

        #region Строковые значения ошибок 

        protected readonly string IsNullOrEmptyError = "Это поле должно быть заполнено";
        protected readonly string IsFiveSymbols = "Не менее 5 символов";
        protected readonly string IsNullPhoto = "Добавьте фотографию";
        protected readonly string IsMatchSymbolsRegex = "Это поле должно содаржать только символы кирилицы";
        protected readonly string IsMatchLatSumbolsRegex = "Это поле должно содержать только символы латиницы";

        #endregion

        #region Регулярные выражения

        //protected readonly Regex RegexSymbols = new Regex("^[А-Яа-я]*$");

        //protected readonly Regex RegexLatSymbols = new Regex("^[A-Za-z]*$");

        #endregion

        #region События

        /// <summary>
        /// Событие изменения свойства (не реализовано так как подключена библиотека FodyPropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        #endregion
    }
}
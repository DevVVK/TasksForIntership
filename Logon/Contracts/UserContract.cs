using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media;
using Logon.Contracts.Validation;
using Logon.Properties;

namespace Logon.Contracts
{
    public class UserContract : BaseValidationContract
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        public string Gender { get; set; }
        public DateTime DateBirth { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PictureName { get; set; }
        public ImageSource Photo { get; set; }
        
        public Visibility VisibleErrorPasword { get; set; } = Visibility.Visible;
        public Visibility VisibleErrorConfirmPassword { get; set; } = Visibility.Visible;

        public string ToolTypePasswordError { get; set; } = "Это поле должно быть заполнено";

        private readonly string _isNullOrEmptyError = "Это поле должно быть заполнено";
        private readonly string _isFiveSymbols = "Не менее 5 символов";
        private readonly string _isNullPhoto = "Добавьте фотографию";
        private readonly string _isMatchSymbolsRegex = "Это поле должно содаржать только символы кирилицы";
        private readonly string _isMatchLatSumbolsRegex = "Это поле должно содержать только символы латиницы";

        private readonly Regex _regexSymbols = new Regex("^[А-Яа-я]*$");
        private readonly Regex _regexLatSymbols = new Regex("^[A-Za-z]*$");

        public bool HasErrorsFields { get; private set; } = false;

        public override string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(FirstName):

                        if (string.IsNullOrEmpty(FirstName))
                        {
                            HasErrorsFields = true; return _isNullOrEmptyError;
                        }
                        if (!_regexSymbols.IsMatch(FirstName))
                        {
                            HasErrorsFields = true; return _isMatchSymbolsRegex;
                        }
                        if (FirstName.Length < 5)
                        {
                            HasErrorsFields = true; return _isFiveSymbols;
                        }

                        HasErrorsFields = false; return string.Empty;

                    case nameof(LastName):

                        if (string.IsNullOrEmpty(LastName))
                        {
                            HasErrorsFields = true; return _isNullOrEmptyError;
                        }
                        if (!_regexSymbols.IsMatch(LastName))
                        {
                            HasErrorsFields = true; return _isMatchSymbolsRegex;
                        }
                        if (LastName.Length < 5)
                        {
                            HasErrorsFields = true; return _isFiveSymbols;
                        }

                        HasErrorsFields = false; return string.Empty;

                    case nameof(Login):

                        if (string.IsNullOrEmpty(Login))
                        {
                            HasErrorsFields = true; return _isNullOrEmptyError;
                        }
                        if (!_regexLatSymbols.IsMatch(Login))
                        {
                            HasErrorsFields = true; return _isMatchLatSumbolsRegex;
                        }
                        if (Login.Length < 5)
                        {
                            HasErrorsFields = true; return _isFiveSymbols;
                        }

                        HasErrorsFields = false; return string.Empty;

                    case nameof(Photo):

                        if (Photo == null)
                        {
                            HasErrorsFields = true; return _isNullPhoto;
                        }

                        HasErrorsFields = false; return string.Empty;

                    case nameof(Gender):

                        if (string.IsNullOrEmpty(Gender))
                        {
                            HasErrorsFields = true; return _isNullOrEmptyError;
                        }

                        HasErrorsFields = false; return string.Empty;
                }

                return string.Empty;
            }
        }
    }
}
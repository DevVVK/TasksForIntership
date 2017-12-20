using Logon.Contracts.Validation;

namespace Logon.Contracts
{
    public class UserContract : BaseValidationContract
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Year { get; set; }

        public string Month { get; set; }

        public int Day { get; set; }

        public string Gender { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string PictureName { get; set; }

        private readonly string _isNullOrEmptyError = "Это поле должно быть заполнено";
        private readonly string _isFiveSymbols = "Не менее 5 символов";

        public override string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(FirstName):

                        if (string.IsNullOrEmpty(FirstName)) return _isNullOrEmptyError;
                        if (FirstName.Length < 5) return _isFiveSymbols;
                        return string.Empty;

                    case nameof(LastName):

                        if (string.IsNullOrEmpty(LastName)) return _isNullOrEmptyError;
                        if (LastName.Length < 5) return _isFiveSymbols;
                        return string.Empty;

                    case nameof(Login):

                        if (string.IsNullOrEmpty(Login)) return _isNullOrEmptyError;
                        if (Login.Length < 5) return _isFiveSymbols;
                        return string.Empty;
                }

                return string.Empty;
            }
        }
    }
}
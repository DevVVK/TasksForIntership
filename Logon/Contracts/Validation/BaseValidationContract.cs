using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Logon.Contracts.Validation
{
    public class BaseValidationContract : INotifyPropertyChanged, IDataErrorInfo, INotifyDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual string this[string columnName] => throw new NotImplementedException(); 

        public string Error { get; }

        private readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                return _errors.Values;

            return _errors.ContainsKey(propertyName) ? _errors[propertyName] : null;
        }

        protected void ClearErrors(string propertyName = "")
        {
            _errors.Remove(propertyName);
            OnErrorsChanged(propertyName);
        }

        protected void AddError(string propertyName, string error)
        {
            _errors.Add(propertyName, new List<string>{error});
        }

        protected void AddErrors(string propertyName, IList<string> errors)
        {
            var changedErrors = false;

            if (!_errors.ContainsKey(propertyName))
            {
                _errors.Add(propertyName, new List<string>(errors));
                changedErrors = true;
            }
            errors.ToList().ForEach(errorValue =>
            {
                if (_errors[propertyName].Contains(errorValue))
                    return;

                _errors[propertyName].Add(errorValue);
                changedErrors = true;
            });
            if (changedErrors)
            {
                OnErrorsChanged(propertyName);
            }
        }

        public bool HasErrors => _errors.Count != 0;
        
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
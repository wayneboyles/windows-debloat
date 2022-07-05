using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Boyles.Tools.WindowsDebloat.ViewModels
{
    public abstract class ViewModel : INotifyPropertyChanged, INotifyDataErrorInfo, IDataErrorInfo
    {
        private readonly Dictionary<string, IList<string>> _validationErrors;

        public event PropertyChangedEventHandler? PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public string this[string propertyName]
        {
            get
            {
                if (string.IsNullOrWhiteSpace(propertyName))
                {
                    return Error;
                }

                if (_validationErrors.ContainsKey(propertyName))
                {
                    return string.Join(Environment.NewLine, _validationErrors[propertyName]);
                }

                return string.Empty;
            }
        }

        public bool HasErrors => _validationErrors.Any();

        public string Error => $"{Environment.NewLine}{GetAllErrors()}";

        protected ViewModel()
        {
            _validationErrors = new Dictionary<string, IList<string>>();
        }

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                return _validationErrors.SelectMany(x => x.Value);
            }

            return _validationErrors.TryGetValue(propertyName, out var errors) ? errors : Enumerable.Empty<object>();
        }

        private IEnumerable<string> GetAllErrors()
        {
            return _validationErrors.SelectMany(v => v.Value).Where(x => !string.IsNullOrEmpty(x));
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            RaisePropertyChanged(propertyName);
            return true;
        }
    }
}

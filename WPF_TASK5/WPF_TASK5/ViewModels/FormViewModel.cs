using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WPF_TASK5.ViewModels
{
    public class FormViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private string _name = "";
        private string _email = "";
        private string _ageText = "";

        public string Name 
        { 
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnChanged(nameof(Name), nameof(IsValid));
                }
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnChanged(nameof(Email), nameof(IsValid));
                }
            }
        }

        public string AgeText
        {
            get { return _ageText; }
            set
            {
                if (_ageText != value)
                {
                    _ageText = value;
                    OnChanged(nameof(AgeText), nameof(IsValid));
                }
            }
        }

        public int? Age => int.TryParse(AgeText, out var v) ? v : null;
        public bool IsValid => string.IsNullOrEmpty(this[nameof(Name)]) && string.IsNullOrEmpty(this[nameof(Email)]) && string.IsNullOrEmpty(this[nameof(AgeText)]);
        public string Error => null!;

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Name):
                        return string.IsNullOrWhiteSpace(Name) ? "Name is mandatory" : null!;

                    case nameof(Email):
                        if (string.IsNullOrWhiteSpace(Email)) return null!;

                        var rx = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

                        return rx.IsMatch(Email) ? null! : "Non valid email format";

                    case nameof(AgeText):
                        if (string.IsNullOrWhiteSpace(AgeText)) return "Age is mandatory";
                        if (!int.TryParse(AgeText, out var age)) return "Age need to be a number";
                        if (age < 18 || age > 120) return "Age need to be less than 120 and greater than 18";

                        return null!;

                    default:
                        return null!;
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnChanged(params string[] names)
        {
            foreach (var name in names) PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}

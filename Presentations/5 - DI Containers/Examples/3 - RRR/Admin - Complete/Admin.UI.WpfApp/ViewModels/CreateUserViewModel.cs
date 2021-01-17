using Admin.Domain.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace Admin.UI.WpfApp.ViewModels
{
    public class CreateUserViewModel : ViewModelBase, IDataErrorInfo
    {
        #region Properties

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (_name == value)
                {
                    return;
                }

                _name = value;
                OnPropertyChanged();
            }
        }
        private string _name;

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                if (_email == value)
                {
                    return;
                }

                _email = value;
                OnPropertyChanged();
            }
        }
        private string _email;

        public string Phone
        {
            get
            {
                return _phone;
            }

            set
            {
                if (_phone == value)
                {
                    return;
                }

                _phone = value;
                OnPropertyChanged();
            }
        }
        private string _phone;

        public string PreferredLanguage
        {
            get
            {
                return _preferredLanguage;
            }

            set
            {
                if (_preferredLanguage == value)
                {
                    return;
                }

                _preferredLanguage = value;
                OnPropertyChanged();
            }
        }
        private string _preferredLanguage;

        public IEnumerable<string> AllPreferredLanguages => new List<string>
        {
            "en",
            "da"
        };

        #endregion

        #region Commands

        public ICommand Create { get; }

        #endregion

        #region IDataErrorInfo Members

        // We would probably do this with some sort of attribute-based approach in real life :-)

        public string Error
        {
            get
            {
                return null;
            }
        }

        public string this[string columnName]
        {
            get
            {
                string error = null;

                switch (columnName)
                {
                    case nameof(Name):
                        {
                            if (string.IsNullOrWhiteSpace(Name) || Name.Trim().Length < 3)
                            {
                                error = "Name must consist of at least three characters";
                            }
                            break;
                        }
                    case nameof(Email):
                        {
                            if (string.IsNullOrWhiteSpace(Email) || Email.Trim().Length < 6)
                            {
                                error = "Email must consist of at least six characters";
                            }
                            break;
                        }
                    case nameof(Phone):
                        {
                            if (string.IsNullOrWhiteSpace(Phone) || Phone.Trim().Length < 8)
                            {
                                error = "Phone must consist of at least eight characters";
                            }
                            break;
                        }
                }

                return error;
            }
        }

        #endregion

        private readonly ICreateUserService _createUserService;

        public CreateUserViewModel(ICreateUserService createUserService)
        {
            _createUserService = createUserService;

            PreferredLanguage = "da";
            Create = new RelayCommand(
                async parameter =>
                {
                    await _createUserService.CreateUserAsync(
                        new User(Name, Email, Phone, PreferredLanguage)
                    );

                    Name = string.Empty;
                    Email = string.Empty;
                    Phone = string.Empty;
                },
                parameter => this.HasOverallError() == false
            );
        }
    }
}

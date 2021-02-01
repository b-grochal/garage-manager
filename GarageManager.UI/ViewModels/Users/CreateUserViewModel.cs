using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using GarageManager.UI.Commands;
using GarageManager.UI.Infrastructure;
using GarageManager.UI.State.Navigator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace GarageManager.UI.ViewModels
{
    public class CreateUserViewModel : BaseViewModel, IDataErrorInfo
    {
        #region Fields

        private User user;
        private string password;
        private string confirmPassword;
        private Dictionary<string, string> dataErrorsDictionary;

        #endregion Fields

        #region ViewModels

        public MessageViewModel ErrorMessageViewModel { get; }

        #endregion ViewModels

        #region Properties

        public User User
        {
            get
            {
                return this.user;
            }
            set
            {
                this.user = value;
            }
        }

        public string UserName
        {
            get
            {
                return this.user.UserName;
            }
            set
            {
                this.user.UserName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ConfirmPassword
        {
            get
            {
                return this.confirmPassword;
            }
            set
            {
                this.confirmPassword = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public string Error => throw new NotImplementedException();

        public Dictionary<string, string> DataErrorsDictionary
        {
            get
            {
                return this.dataErrorsDictionary;
            }
            private set
            {
                this.dataErrorsDictionary = value;
            }
        }

        public bool IsDataValid
        {
            get
            {
                foreach (KeyValuePair<string, string> item in dataErrorsDictionary)
                {
                    if (item.Value != null)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        #endregion Properties

        #region Indexers

        public string this[string propertyName]
        {
            get
            {
                string result = null;

                switch (propertyName)
                {
                    case nameof(UserName):
                        if (string.IsNullOrWhiteSpace(UserName))
                            result = "Username cannot be empty.";
                        break;
                    case nameof(Password):
                        if (string.IsNullOrWhiteSpace(Password))
                            result = "Password cannot be empty.";
                        break;
                    case nameof(ConfirmPassword):
                        if (string.IsNullOrWhiteSpace(ConfirmPassword))
                            result = "Password cannot be empty.";
                        else if (!Password.Equals(ConfirmPassword))
                            result = "Passwords do not match.";
                        break;
                }

                if (DataErrorsDictionary.ContainsKey(propertyName))
                    DataErrorsDictionary[propertyName] = result;
                else
                    DataErrorsDictionary.Add(propertyName, result);

                OnPropertyChanged(nameof(DataErrorsDictionary));
                return result;
            }
        }

        #endregion Indexers

        #region Commands

        public ICommand CreateUserCommand { get; }

        #endregion Commands

        #region Constructors

        public CreateUserViewModel(IUsersService usersService, INavigator navigator, IViewModelFactory viewModelFactory, IMessageBoxService messageBoxService)
        {
            this.DataErrorsDictionary = new Dictionary<string, string>();
            this.User = new User();
            this.CreateUserCommand = new CreateUserCommand(this, usersService, navigator, viewModelFactory, messageBoxService);
            this.ErrorMessageViewModel = new MessageViewModel();
        }

        #endregion Constructors
    }
}

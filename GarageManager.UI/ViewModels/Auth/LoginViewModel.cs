using GarageManager.Services.Interfaces;
using GarageManager.UI.Commands;
using GarageManager.UI.Infrastructure;
using GarageManager.UI.State.Authenticator;
using GarageManager.UI.State.Navigator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GarageManager.UI.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Fields

        private string _userName;
        private string _password;

        #endregion Fields

        #region Properties

        public string UserName
        {
            get
            {
                return this._userName;
            }
            set
            {
                this._userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        public string Password
        {
            get
            {
                return this._password;
            }
            set
            {
                this._password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        #endregion Properties

        #region Commands

        public ICommand LoginCommand { get; }

        #endregion Commands

        #region ViewModels

        public MessageViewModel ErrorMessageViewModel { get; }

        #endregion ViewModels

        #region Constructors

        public LoginViewModel(IAuthService authService, IAuthenticator authenticator, INavigator navigator, IViewModelFactory viewModelFactory)
        {
            this.LoginCommand = new LoginCommand(this, authService, authenticator, navigator, viewModelFactory);
            this.ErrorMessageViewModel = new MessageViewModel();
        }

        #endregion Constructors
    }
}

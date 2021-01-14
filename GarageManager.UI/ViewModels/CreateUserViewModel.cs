using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using GarageManager.UI.Commands;
using GarageManager.UI.Infrastructure;
using GarageManager.UI.State.Navigator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GarageManager.UI.ViewModels
{
    public class CreateUserViewModel : BaseViewModel
    {
        #region Fields

        private User user;
        private string password;
        private string confirmPassword;

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

        #endregion Properties

        #region Commands

        public ICommand CreateUserCommand { get; }

        #endregion Commands

        #region Constructors

        public CreateUserViewModel(IUsersService usersService, INavigator navigator, IViewModelFactory viewModelFactory)
        {
            this.User = new User();
            this.CreateUserCommand = new CreateUserCommand(this, usersService, navigator, viewModelFactory);
            this.ErrorMessageViewModel = new MessageViewModel();
        }

        #endregion Constructors
    }
}

using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using GarageManager.Services.SearchCriteria;
using GarageManager.UI.Commands;
using GarageManager.UI.Commands.Users;
using GarageManager.UI.Infrastructure;
using GarageManager.UI.State.Navigator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace GarageManager.UI.ViewModels
{
    public class UsersListViewModel : BaseViewModel
    {
        #region Fields

        private UsersListSearchCriteria usersListSearchCriteria;
        private IEnumerable<User> users;
        private User selectedUser;

        #endregion Fields

        #region Properties

        public UsersListSearchCriteria UsersListSearchCriteria
        {
            get
            {
                return usersListSearchCriteria;
            }
        }

        public string LoginSearchCirteria
        {
            get
            {
                return this.usersListSearchCriteria.Login;
            }
            set
            {
                this.usersListSearchCriteria.Login = value;
                OnPropertyChanged(nameof(LoginSearchCirteria));
            }
        }


        public IEnumerable<User> Users 
        { 
            get 
            {
                return this.users;
            } 
            set 
            {
                this.users = value;
                OnPropertyChanged(nameof(Users));
            } 
        }

        public User SelectedUser
        {
            get
            {
                return this.selectedUser;
            }
            set
            {
                this.selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }

        #endregion Properties

        #region Commands

        public ICommand SearchUsersListCommand { get; }
        public ICommand ShowCreateUserViewCommand { get; }
        public ICommand DeleteUserCommand { get; }
        public ICommand ResetUsersListSearchCriteriaCommand { get; }

        #endregion Commands

        #region Constructors

        public UsersListViewModel(IUsersService usersService, INavigator navigator, IViewModelFactory viewModelFactory)
        {
            this.usersListSearchCriteria = new UsersListSearchCriteria();
            this.SearchUsersListCommand = new SearchUsersListCommand(this, usersService);
            this.ShowCreateUserViewCommand = new ShowCreateUserViewCommand(navigator, viewModelFactory);
            this.DeleteUserCommand = new DeleteUserCommand(this, usersService);
            this.ResetUsersListSearchCriteriaCommand = new ResetUsersListSearchCriteriaCommand(this, usersService);
        }

        #endregion Constructors
    }
}

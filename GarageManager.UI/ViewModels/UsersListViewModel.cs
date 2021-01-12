using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using GarageManager.Services.SearchCriteria;
using GarageManager.UI.Commands;
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
                this.usersListSearchCriteria.Login = value;;
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

        #endregion Properties

        #region Commands

        public ICommand SearchUsersListCommand { get; }
        public ICommand ShowCreateUserViewCommand { get; }

        #endregion Commands

        #region Constructors

        public UsersListViewModel(IUsersService usersService, INavigator navigator, IViewModelFactory viewModelFactory)
        {
            this.usersListSearchCriteria = new UsersListSearchCriteria();
            this.SearchUsersListCommand = new SearchUsersListCommand(this, usersService);
            this.ShowCreateUserViewCommand = new ShowCreateUserViewCommand(navigator, viewModelFactory);
        }

        #endregion Constructors
    }
}

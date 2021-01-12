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

        private UsersListSearchCriteria _usersListSearchCriteria;
        private IEnumerable<User> _users;

        #endregion Fields

        #region Properties

        public UsersListSearchCriteria UsersListSearchCriteria
        {
            get
            {
                return _usersListSearchCriteria;
            }
        }

        public string LoginSearchCirteria
        {
            get
            {
                return this._usersListSearchCriteria.Login;
            }
            set
            {
                this._usersListSearchCriteria.Login = value;;
                OnPropertyChanged(nameof(LoginSearchCirteria));
            }
        }


        public IEnumerable<User> Users 
        { 
            get 
            {
                return this._users;
            } 
            set 
            {
                this._users = value;
                OnPropertyChanged(nameof(Users));
            } 
        }

        #endregion Properties

        #region Commands

        public ICommand SearchUsersListCommand { get; }

        #endregion Commands

        #region Constructors

        public UsersListViewModel(IUsersService usersService, INavigator navigator, IViewModelFactory viewModelFactory)
        {
            _usersListSearchCriteria = new UsersListSearchCriteria();
            SearchUsersListCommand = new SearchUsersListCommand(this, usersService);
        }

        #endregion Constructors
    }
}

using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using GarageManager.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.UI.Commands
{
    public class SearchUsersListCommand : BaseAsyncCommand
    {
        private readonly UsersListViewModel _usersListViewModel;
        private readonly IUsersService _usersService;

        public SearchUsersListCommand(UsersListViewModel usersListViewModel, IUsersService usersService)
        {
            this._usersListViewModel = usersListViewModel;
            this._usersService = usersService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            IEnumerable<User> filteredUsers = await _usersService.GetUsers(_usersListViewModel.UsersListSearchCriteria);
            _usersListViewModel.Users = filteredUsers;
        }
    }
}

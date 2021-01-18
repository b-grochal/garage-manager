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
        private readonly UsersListViewModel usersListViewModel;
        private readonly IUsersService usersService;

        public SearchUsersListCommand(UsersListViewModel usersListViewModel, IUsersService usersService)
        {
            this.usersListViewModel = usersListViewModel;
            this.usersService = usersService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            IEnumerable<User> filteredUsers = await usersService.GetUsers(usersListViewModel.UsersListSearchCriteria);
            usersListViewModel.Users = filteredUsers;
        }
    }
}

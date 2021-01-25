using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using GarageManager.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.UI.Commands.Users
{
    public class ResetUsersListSearchCriteriaCommand : BaseAsyncCommand
    {
        private readonly UsersListViewModel usersListViewModel;
        private readonly IUsersService usersServices;

        public ResetUsersListSearchCriteriaCommand(UsersListViewModel usersListViewModel, IUsersService usersServices)
        {
            this.usersListViewModel = usersListViewModel;
            this.usersServices = usersServices;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            usersListViewModel.LoginSearchCirteria= null;
            IEnumerable<User> users = await usersServices.GetUsers();
            usersListViewModel.Users = users;
        }
    }
}

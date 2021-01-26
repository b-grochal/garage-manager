using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using GarageManager.UI.Infrastructure;
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
        private readonly IMessageBoxService messageBoxService;

        public SearchUsersListCommand(UsersListViewModel usersListViewModel, IUsersService usersService, IMessageBoxService messageBoxService)
        {
            this.usersListViewModel = usersListViewModel;
            this.usersService = usersService;
            this.messageBoxService = messageBoxService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                IEnumerable<User> filteredUsers = await usersService.GetUsers(usersListViewModel.UsersListSearchCriteria);
                usersListViewModel.Users = filteredUsers;
            }
            catch (Exception)
            {
                messageBoxService.ShowErrorMessageBox("Error", "An unknown error occurred.");
            }   
        }
    }
}

using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using GarageManager.UI.Infrastructure;
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
        private readonly IMessageBoxService messageBoxService;

        public ResetUsersListSearchCriteriaCommand(UsersListViewModel usersListViewModel, IUsersService usersServices, IMessageBoxService messageBoxService)
        {
            this.usersListViewModel = usersListViewModel;
            this.usersServices = usersServices;
            this.messageBoxService = messageBoxService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                usersListViewModel.LoginSearchCirteria = null;
                IEnumerable<User> users = await usersServices.GetUsers();
                usersListViewModel.Users = users;
            }
            catch (Exception)
            {
                messageBoxService.ShowErrorMessageBox("Error", "An unknown error occurred.");
            }
            
        }
    }
}

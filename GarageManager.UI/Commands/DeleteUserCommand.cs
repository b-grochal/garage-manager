using GarageManager.Services.Interfaces;
using GarageManager.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.UI.Commands
{
    public class DeleteUserCommand : BaseAsyncCommand
    {
        private readonly UsersListViewModel usersListViewModel;
        private readonly IUsersService usersService;

        public DeleteUserCommand(UsersListViewModel usersListViewModel, IUsersService usersService)
        {
            this.usersListViewModel = usersListViewModel;
            this.usersService = usersService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await usersService.DeleteUser(usersListViewModel.SelectedUser.UserId);
            var users = await usersService.GetUsers();
            usersListViewModel.Users = users;
        }

        public override bool CanExecute(object parameter)
        {
            return !IsExecuting && this.usersListViewModel.SelectedUser != null;
        }
    }
}

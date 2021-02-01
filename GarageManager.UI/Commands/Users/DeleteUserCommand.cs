using GarageManager.Services.Exceptions;
using GarageManager.Services.Interfaces;
using GarageManager.UI.Infrastructure;
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
        private readonly IMessageBoxService messageBoxService;

        public DeleteUserCommand(UsersListViewModel usersListViewModel, IUsersService usersService, IMessageBoxService messageBoxService)
        {
            this.usersListViewModel = usersListViewModel;
            this.usersService = usersService;
            this.messageBoxService = messageBoxService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                bool isDeleteOperationConfirmed = messageBoxService.ShowConfirmationMessageBox("Delete user", $"Are you sure you want to delete car {usersListViewModel.SelectedUser.UserName}?");
                if(isDeleteOperationConfirmed)
                {
                    await usersService.DeleteUser(usersListViewModel.SelectedUser.UserId);
                    var users = await usersService.GetUsers();
                    usersListViewModel.Users = users;
                    messageBoxService.ShowInformationMessageBox("Delete user", "User was successfully deleted.");
                }
            }
            catch (UserNotFoundException ex)
            {
                messageBoxService.ShowErrorMessageBox("Error", $"Selected user with ID: {ex.UserId} not found.");
            }
            catch (Exception)
            {
                messageBoxService.ShowErrorMessageBox("Error", "Failed to delete user.");
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !IsExecuting && this.usersListViewModel.SelectedUser != null;
        }
    }
}

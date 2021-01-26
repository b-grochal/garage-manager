using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using GarageManager.UI.Infrastructure;
using GarageManager.UI.State.Navigator;
using GarageManager.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.UI.Commands
{
    public class CreateUserCommand : BaseAsyncCommand
    {
        private readonly CreateUserViewModel createUserViewModel;
        private readonly IUsersService usersService;
        private readonly INavigator navigator;
        private readonly IViewModelFactory viewModelFactory;
        private readonly IMessageBoxService messageBoxService;

        public CreateUserCommand(CreateUserViewModel createUserViewModel, IUsersService usersService, INavigator navigator, IViewModelFactory viewModelFactory, IMessageBoxService messageBoxService)
        {
            this.createUserViewModel = createUserViewModel;
            this.usersService = usersService;
            this.navigator = navigator;
            this.viewModelFactory = viewModelFactory;
            this.messageBoxService = messageBoxService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await usersService.CreateUser(createUserViewModel.User, createUserViewModel.Password);
                IEnumerable<User> users = await usersService.GetUsers();
                UsersListViewModel usersListViewModel = (UsersListViewModel)viewModelFactory.CreateViewModel(ViewType.UsersList);
                usersListViewModel.Users = users;
                navigator.CurrentViewModel = usersListViewModel;
                messageBoxService.ShowInformationMessageBox("Create user", "User was successfully created.");
            }
            catch (Exception)
            {
                createUserViewModel.ErrorMessage = "Failed to create user.";
            }
        }
    }
}

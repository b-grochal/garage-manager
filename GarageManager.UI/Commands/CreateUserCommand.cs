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

        public CreateUserCommand(CreateUserViewModel createUserViewModel, IUsersService usersService, INavigator navigator, IViewModelFactory viewModelFactory)
        {
            this.createUserViewModel = createUserViewModel;
            this.usersService = usersService;
            this.navigator = navigator;
            this.viewModelFactory = viewModelFactory;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await usersService.CreateUser(createUserViewModel.User, createUserViewModel.Password, createUserViewModel.ConfirmPassword);
            IEnumerable<User> users = await usersService.GetUsers();
            UsersListViewModel usersListViewModel = (UsersListViewModel)viewModelFactory.CreateViewModel(ViewType.UsersList);
            usersListViewModel.Users = users;
            navigator.CurrentViewModel = usersListViewModel;
        }
    }
}

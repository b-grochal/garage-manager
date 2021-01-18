using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using GarageManager.UI.Infrastructure;
using GarageManager.UI.State.Navigator;
using GarageManager.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.UI.Commands
{
    public class ShowUsersListCommand : BaseAsyncCommand
    {
        private readonly IUsersService usersService;
        private readonly INavigator navigator;
        private readonly IViewModelFactory viewModelFactory;

        public ShowUsersListCommand(IUsersService usersService, INavigator navigator, IViewModelFactory viewModelFactory)
        {
            this.usersService = usersService;
            this.navigator = navigator;
            this.viewModelFactory = viewModelFactory;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var users = await usersService.GetUsers();
            UsersListViewModel usersListViewModel = (UsersListViewModel)viewModelFactory.CreateViewModel(ViewType.UsersList);
            usersListViewModel.Users = new ObservableCollection<User>(users);
            navigator.CurrentViewModel = usersListViewModel;
        }
    }
}

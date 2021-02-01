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
        private readonly IMessageBoxService messageBoxService;

        public ShowUsersListCommand(IUsersService usersService, INavigator navigator, IViewModelFactory viewModelFactory, IMessageBoxService messageBoxService)
        {
            this.usersService = usersService;
            this.navigator = navigator;
            this.viewModelFactory = viewModelFactory;
            this.messageBoxService = messageBoxService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                var users = await usersService.GetUsers();
                UsersListViewModel usersListViewModel = (UsersListViewModel)viewModelFactory.CreateViewModel(ViewType.UsersList);
                usersListViewModel.Users = new ObservableCollection<User>(users);
                navigator.CurrentViewModel = usersListViewModel;
            }
            catch (Exception)
            {
                messageBoxService.ShowErrorMessageBox("Error", "An unknown error occurred.");
            }
        }
    }
}

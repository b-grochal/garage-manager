using GarageManager.Services.Interfaces;
using GarageManager.UI.Commands;
using GarageManager.UI.Infrastructure;
using GarageManager.UI.State.Authenticator;
using GarageManager.UI.State.Navigator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GarageManager.UI.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IViewModelFactory _viewModelFactory;
        private readonly IAuthenticator _authenticator;
        private readonly INavigator _navigator;
        private readonly IUsersService _usersService;

        public bool IsLoggedIn => _authenticator.IsLoggedIn;
        public BaseViewModel CurrentViewModel => _navigator.CurrentViewModel;

        public ICommand ShowHomePageCommand { get; }
        public ICommand ShowUsersListCommand { get; }

        public MainViewModel(IViewModelFactory viewModelFactory, IAuthenticator authenticator, INavigator navigator, IUsersService usersSerivce)
        {
            this._viewModelFactory = viewModelFactory;
            this._authenticator = authenticator;
            this._navigator = navigator;
            this._usersService = usersSerivce;


            this.ShowHomePageCommand = new ShowHomePageCommand(navigator, viewModelFactory);
            this.ShowUsersListCommand = new ShowUsersListCommand(usersSerivce, navigator, viewModelFactory);

            _navigator.StateChanged += Navigator_StateChanged;
            _authenticator.StateChanged += Authenticator_StateChanged;

            _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(ViewType.Login);
        }

        private void Authenticator_StateChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
        }

        private void Navigator_StateChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}

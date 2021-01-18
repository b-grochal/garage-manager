using GarageManager.Services.Implementation;
using GarageManager.Services.Interfaces;
using GarageManager.UI.Infrastructure;
using GarageManager.UI.State.Authenticator;
using GarageManager.UI.State.Navigator;
using GarageManager.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.UI.Commands
{
    public class LoginCommand : BaseAsyncCommand
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly IAuthService _authService;
        private readonly IAuthenticator _authenticator;
        private readonly INavigator _navigator;
        private readonly IViewModelFactory _viewModelFactory;

        public LoginCommand(LoginViewModel loginViewModel, IAuthService auhtService, IAuthenticator authenticator, INavigator navigator, IViewModelFactory viewModelFactory)
        {
            this._loginViewModel = loginViewModel;
            this._authService = auhtService;
            this._authenticator = authenticator;
            this._navigator = navigator;
            this._viewModelFactory = viewModelFactory;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _loginViewModel.ErrorMessage = string.Empty;

            try
            {
                var user = await _authService.Login(_loginViewModel.UserName, _loginViewModel.Password);
                _authenticator.Login(user);
                var homeViewModel = _viewModelFactory.CreateViewModel(ViewType.Home);
                _navigator.CurrentViewModel = homeViewModel;
            }
            //catch (UserNotFoundException)
            //{
            //    _loginViewModel.ErrorMessage = "Username does not exist.";
            //}
            //catch (InvalidPasswordException)
            //{
            //    _loginViewModel.ErrorMessage = "Incorrect password.";
            //}
            catch (Exception e)
            {
                _loginViewModel.ErrorMessage = "Login failed.";
            }
        }
    }
}

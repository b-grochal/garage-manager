using GarageManager.Services.Exceptions;
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
        private readonly LoginViewModel loginViewModel;
        private readonly IAuthService authService;
        private readonly IAuthenticator authenticator;
        private readonly INavigator navigator;
        private readonly IViewModelFactory viewModelFactory;

        public LoginCommand(LoginViewModel loginViewModel, IAuthService auhtService, IAuthenticator authenticator, INavigator navigator, IViewModelFactory viewModelFactory)
        {
            this.loginViewModel = loginViewModel;
            this.authService = auhtService;
            this.authenticator = authenticator;
            this.navigator = navigator;
            this.viewModelFactory = viewModelFactory;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            loginViewModel.ErrorMessage = string.Empty;

            try
            {
                var user = await authService.Login(loginViewModel.UserName, loginViewModel.Password);
                authenticator.Login(user);
                var homeViewModel = viewModelFactory.CreateViewModel(ViewType.Home);
                navigator.CurrentViewModel = homeViewModel;
            }
            catch (InvalidUserNameException ex)
            {
                loginViewModel.ErrorMessage = $"{ex.UserName} does not exist.";
            }
            catch (InvalidPasswordException)
            {
                loginViewModel.ErrorMessage = "Incorrect password.";
            }
            catch (Exception)
            {
                loginViewModel.ErrorMessage = "Login failed.";
            }
        }
    }
}

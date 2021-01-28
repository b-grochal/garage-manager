using GarageManager.Services.Interfaces;
using GarageManager.UI.Commands;
using GarageManager.UI.Commands.Cars;
using GarageManager.UI.Commands.Services;
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
        #region Fields

        private readonly IViewModelFactory viewModelFactory;
        private readonly IAuthenticator authenticator;
        private readonly INavigator navigator;
        private readonly IUsersService usersService;

        #endregion Fields

        #region Properties

        public bool IsLoggedIn => authenticator.IsLoggedIn;
        public BaseViewModel CurrentViewModel => navigator.CurrentViewModel;

        #endregion Properties

        #region Commands

        public ICommand ShowHomePageCommand { get; }
        public ICommand ShowUsersListCommand { get; }
        public ICommand ShowCustomersListCommand { get; }
        public ICommand ShowCarsListCommand { get;  }
        public ICommand ShowServicesListCommand { get; }

        #endregion Commands

        #region Constructors

        public MainViewModel(
            IViewModelFactory viewModelFactory, 
            IAuthenticator authenticator, 
            INavigator navigator, 
            IUsersService usersSerivce, 
            ICustomersService customersService, 
            ICarsService carsService,
            IServicesService servicesService,
            IMessageBoxService messageBoxService)
        {
            this.viewModelFactory = viewModelFactory;
            this.authenticator = authenticator;
            this.navigator = navigator;
            this.usersService = usersSerivce;


            this.ShowHomePageCommand = new ShowHomeViewCommand(navigator, viewModelFactory);
            this.ShowUsersListCommand = new ShowUsersListCommand(usersSerivce, navigator, viewModelFactory, messageBoxService);
            this.ShowCustomersListCommand = new ShowCustomersListCommand(customersService, navigator, viewModelFactory, messageBoxService);
            this.ShowCarsListCommand = new ShowCarsListCommand(carsService, navigator, viewModelFactory, messageBoxService);
            this.ShowServicesListCommand = new ShowServicesListCommand(servicesService, navigator, viewModelFactory, messageBoxService);

            this.navigator.StateChanged += Navigator_StateChanged;
            this.authenticator.StateChanged += Authenticator_StateChanged;

            this.navigator.CurrentViewModel = this.viewModelFactory.CreateViewModel(ViewType.Login);
        }

        #endregion Constructors

        #region Methods

        private void Authenticator_StateChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
        }

        private void Navigator_StateChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        #endregion Methods
    }
}

using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using GarageManager.UI.Infrastructure;
using GarageManager.UI.State.Navigator;
using GarageManager.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.UI.Commands.Cars
{
    public class ShowCreateCarViewCommand : BaseAsyncCommand
    {
        private readonly ICustomersService customersService;
        private readonly INavigator navigator;
        private readonly IViewModelFactory viewModelFactory;
        private readonly IMessageBoxService messageBoxService;

        public ShowCreateCarViewCommand(ICustomersService customersService, INavigator navigator, IViewModelFactory viewModelFactory, IMessageBoxService messageBoxService)
        {
            this.customersService = customersService;
            this.navigator = navigator;
            this.viewModelFactory = viewModelFactory;
            this.messageBoxService = messageBoxService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                IEnumerable<Customer> customers = await customersService.GetCustomers();
                CreateCarViewModel createCarViewModel = (CreateCarViewModel)viewModelFactory.CreateViewModel(ViewType.CreateCar);
                createCarViewModel.Customers = customers;
                navigator.CurrentViewModel = createCarViewModel;
            }
            catch(Exception)
            {
                messageBoxService.ShowErrorMessageBox("An unknown error occurred.", "Error");
            }
        }
    }
}

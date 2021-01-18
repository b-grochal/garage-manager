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
    public class CreateCustomerCommand : BaseAsyncCommand
    {
        private readonly CreateCustomerViewModel createCustomerViewModel;
        private readonly ICustomersService customersService;
        private readonly INavigator navigator;
        private readonly IViewModelFactory viewModelFactory;

        public CreateCustomerCommand(CreateCustomerViewModel createCustomerViewModel, ICustomersService customersService, INavigator navigator, IViewModelFactory viewModelFactory)
        {
            this.createCustomerViewModel = createCustomerViewModel;
            this.customersService = customersService;
            this.navigator = navigator;
            this.viewModelFactory = viewModelFactory;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await customersService.CreateCustomer(createCustomerViewModel.Customer);
            IEnumerable<Customer> customers = await customersService.GetCustomers();
            CustomersListViewModel customersListViewModel = (CustomersListViewModel)viewModelFactory.CreateViewModel(ViewType.CustomersList);
            customersListViewModel.Customers = customers;
            navigator.CurrentViewModel = customersListViewModel;
        }
    }
}

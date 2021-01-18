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
    public class EditCustomerCommand : BaseAsyncCommand
    {
        private readonly EditCustomerViewModel editCustomerViewModel;
        private readonly ICustomersService customersService;
        private readonly INavigator navigator;
        private readonly IViewModelFactory viewModelFactory;

        public EditCustomerCommand(EditCustomerViewModel editCustomerViewModel, ICustomersService customersService, INavigator navigator, IViewModelFactory viewModelFactory)
        {
            this.editCustomerViewModel = editCustomerViewModel;
            this.customersService = customersService;
            this.navigator = navigator;
            this.viewModelFactory = viewModelFactory;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await customersService.EditCustomer(editCustomerViewModel.Customer);
            IEnumerable<Customer> customers = await customersService.GetCustomers();
            CustomersListViewModel customersListViewModel = (CustomersListViewModel)viewModelFactory.CreateViewModel(ViewType.CustomersList);
            customersListViewModel.Customers = customers;
            navigator.CurrentViewModel = customersListViewModel;
        }
    }
}

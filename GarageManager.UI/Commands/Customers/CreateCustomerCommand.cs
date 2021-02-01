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
        private readonly IMessageBoxService messageBoxService;

        public CreateCustomerCommand(CreateCustomerViewModel createCustomerViewModel, ICustomersService customersService, INavigator navigator, IViewModelFactory viewModelFactory, IMessageBoxService messageBoxService)
        {
            this.createCustomerViewModel = createCustomerViewModel;
            this.customersService = customersService;
            this.navigator = navigator;
            this.viewModelFactory = viewModelFactory;
            this.messageBoxService = messageBoxService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            createCustomerViewModel.ErrorMessage = string.Empty;

            try
            {
                await customersService.CreateCustomer(createCustomerViewModel.Customer);
                IEnumerable<Customer> customers = await customersService.GetCustomers();
                CustomersListViewModel customersListViewModel = (CustomersListViewModel)viewModelFactory.CreateViewModel(ViewType.CustomersList);
                customersListViewModel.Customers = customers;
                navigator.CurrentViewModel = customersListViewModel;
                messageBoxService.ShowInformationMessageBox("Create customer", "Customer was successfullt created.");
            }
            catch (Exception)
            {
                createCustomerViewModel.ErrorMessage = "Failed to create customer";
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !IsExecuting && createCustomerViewModel.IsDataValid;
        }
    }
}

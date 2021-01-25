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
        private readonly IMessageBoxService messageBoxService;

        public EditCustomerCommand(EditCustomerViewModel editCustomerViewModel, ICustomersService customersService, INavigator navigator, IViewModelFactory viewModelFactory, IMessageBoxService messageBoxService)
        {
            this.editCustomerViewModel = editCustomerViewModel;
            this.customersService = customersService;
            this.navigator = navigator;
            this.viewModelFactory = viewModelFactory;
            this.messageBoxService = messageBoxService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            editCustomerViewModel.ErrorMessage = string.Empty;

            try
            {
                await customersService.EditCustomer(editCustomerViewModel.Customer);
                IEnumerable<Customer> customers = await customersService.GetCustomers();
                CustomersListViewModel customersListViewModel = (CustomersListViewModel)viewModelFactory.CreateViewModel(ViewType.CustomersList);
                customersListViewModel.Customers = customers;
                navigator.CurrentViewModel = customersListViewModel;
                messageBoxService.ShowInformationMessageBox("Edit customer", "Customer was successfully edited.");
            }
            catch (Exception)
            {
                editCustomerViewModel.ErrorMessage = "Failed to edit customer.";
            }
        }
    }
}

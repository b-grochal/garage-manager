using GarageManager.Services.Interfaces;
using GarageManager.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.UI.Commands
{
    public class DeleteCustomerCommand : BaseAsyncCommand
    {
        private readonly CustomersListViewModel customersListViewModel;
        private readonly ICustomersService customersService;

        public DeleteCustomerCommand(CustomersListViewModel customersListViewModel, ICustomersService customersService)
        {
            this.customersListViewModel = customersListViewModel;
            this.customersService = customersService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await customersService.DeleteCustomer(customersListViewModel.SelectedCustomer.CustomerId);
            var customers = await customersService.GetCustomers();
            customersListViewModel.Customers = customers;
        }

        public override bool CanExecute(object parameter)
        {
            return !IsExecuting && this.customersListViewModel.SelectedCustomer!= null;
        }
    }
}

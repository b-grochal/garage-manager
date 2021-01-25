using GarageManager.Services.Exceptions;
using GarageManager.Services.Interfaces;
using GarageManager.UI.Infrastructure;
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
        private readonly IMessageBoxService messageBoxService;

        public DeleteCustomerCommand(CustomersListViewModel customersListViewModel, ICustomersService customersService, IMessageBoxService messageBoxService)
        {
            this.customersListViewModel = customersListViewModel;
            this.customersService = customersService;
            this.messageBoxService = messageBoxService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                bool isDeleteOperationConfirmed = messageBoxService.ShowConfirmationMessageBox("Delete customer", $"Are you sure you want to delete car {customersListViewModel.SelectedCustomer.FullName}?");
                if(isDeleteOperationConfirmed)
                {
                    await customersService.DeleteCustomer(customersListViewModel.SelectedCustomer.CustomerId);
                    var customers = await customersService.GetCustomers();
                    customersListViewModel.Customers = customers;
                    messageBoxService.ShowInformationMessageBox("Delete customer", "Customer was successfully deleted.");
                }
            }
            catch (CustomerNotFoundException ex)
            {
                messageBoxService.ShowErrorMessageBox("Error", $"Selected customer with ID: {ex.CustomerId} not found.");
            }
            catch (Exception)
            {
                messageBoxService.ShowErrorMessageBox("Error", "Failed to delete customer.");
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !IsExecuting && this.customersListViewModel.SelectedCustomer!= null;
        }
    }
}

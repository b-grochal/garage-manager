using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using GarageManager.UI.Infrastructure;
using GarageManager.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.UI.Commands.Customers
{
    public class ResetCustomersListSearchCriteriaCommand : BaseAsyncCommand
    {
        private readonly CustomersListViewModel customersListViewModel;
        private readonly ICustomersService customersService;
        private readonly IMessageBoxService messageBoxService;

        public ResetCustomersListSearchCriteriaCommand(CustomersListViewModel customersListViewModel, ICustomersService customersService, IMessageBoxService messageBoxService)
        {
            this.customersListViewModel = customersListViewModel;
            this.customersService = customersService;
            this.messageBoxService = messageBoxService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                customersListViewModel.FirstNameSearchCirteria = null;
                customersListViewModel.LastNameSearchCirteria = null;
                IEnumerable<Customer> customers = await customersService.GetCustomers();
                customersListViewModel.Customers = customers;
            }
            catch (Exception)
            {
                messageBoxService.ShowErrorMessageBox("Error", "An unknown error occurred.");
            }
        }
    }
}

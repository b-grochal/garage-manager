using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using GarageManager.UI.Infrastructure;
using GarageManager.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.UI.Commands
{
    public class SearchCustomersListCommand : BaseAsyncCommand
    {
        private readonly CustomersListViewModel customersListViewModel;
        private readonly ICustomersService customersService;
        private readonly IMessageBoxService messageBoxService;

        public SearchCustomersListCommand(CustomersListViewModel customersListViewModel, ICustomersService customersService, IMessageBoxService messageBoxService)
        {
            this.customersListViewModel = customersListViewModel;
            this.customersService = customersService;
            this.messageBoxService = messageBoxService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                IEnumerable<Customer> filteredCustomers = await customersService.GetCustomers(customersListViewModel.CustomersListSearchCriteria);
                customersListViewModel.Customers = filteredCustomers;
            }
            catch (Exception)
            {
                messageBoxService.ShowErrorMessageBox("Error", "An unknown error occurred.");
            }
        }
    }
}

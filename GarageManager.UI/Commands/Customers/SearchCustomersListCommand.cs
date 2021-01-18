using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
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

        public SearchCustomersListCommand(CustomersListViewModel customersListViewModel, ICustomersService customersService)
        {
            this.customersListViewModel = customersListViewModel;
            this.customersService = customersService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            IEnumerable<Customer> filteredCustomers = await customersService.GetCustomers(customersListViewModel.CustomersListSearchCriteria);
            customersListViewModel.Customers = filteredCustomers;
        }
    }
}

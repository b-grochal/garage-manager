using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
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

        public ResetCustomersListSearchCriteriaCommand(CustomersListViewModel customersListViewModel, ICustomersService customersService)
        {
            this.customersListViewModel = customersListViewModel;
            this.customersService = customersService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            customersListViewModel.FirstNameSearchCirteria = null;
            customersListViewModel.LastNameSearchCirteria = null;
            IEnumerable<Customer> customers = await customersService.GetCustomers();
            customersListViewModel.Customers = customers;
        }
    }
}

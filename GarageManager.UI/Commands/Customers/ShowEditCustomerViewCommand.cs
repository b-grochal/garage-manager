using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using GarageManager.UI.Infrastructure;
using GarageManager.UI.State.Navigator;
using GarageManager.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GarageManager.UI.Commands
{
    public class ShowEditCustomerViewCommand : BaseAsyncCommand
    {
        private readonly CustomersListViewModel customersListViewModel;
        private readonly ICustomersService customersService;
        private readonly INavigator navigator;
        private readonly IViewModelFactory viewModelFactory;

        public ShowEditCustomerViewCommand(CustomersListViewModel customersListViewModel ,ICustomersService customersService, INavigator navigator, IViewModelFactory viewModelFactory)
        {
            this.customersListViewModel = customersListViewModel;
            this.customersService = customersService;
            this.navigator = navigator;
            this.viewModelFactory = viewModelFactory;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            Customer customer = await customersService.GetCustomer(customersListViewModel.SelectedCustomer.CustomerId);
            EditCustomerViewModel editCustomerViewModel = (EditCustomerViewModel)viewModelFactory.CreateViewModel(ViewType.EditCustomer);
            editCustomerViewModel.Customer = customer;
            navigator.CurrentViewModel = editCustomerViewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return !IsExecuting && this.customersListViewModel.SelectedCustomer != null;
        }
    }
}

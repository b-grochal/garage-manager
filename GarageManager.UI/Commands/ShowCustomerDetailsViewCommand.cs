﻿using GarageManager.Data.Entities;
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
    public class ShowCustomerDetailsViewCommand : BaseAsyncCommand
    {
        private readonly CustomersListViewModel customersListViewModel;
        private readonly ICustomersService customersService;
        private readonly INavigator navigator;
        private readonly IViewModelFactory viewModelFactory;

        public ShowCustomerDetailsViewCommand(CustomersListViewModel customersListViewModel, ICustomersService customersService, INavigator navigator, IViewModelFactory viewModelFactory)
        {
            this.customersListViewModel = customersListViewModel;
            this.customersService = customersService;
            this.navigator = navigator;
            this.viewModelFactory = viewModelFactory;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            Customer customer = await customersService.GetCustomer(customersListViewModel.SelectedCustomer.CustomerId);
            CustomerDetailsViewModel editCustomerViewModel = (CustomerDetailsViewModel)viewModelFactory.CreateViewModel(ViewType.CustomersDetails);
            editCustomerViewModel.Customer = customer;
            navigator.CurrentViewModel = editCustomerViewModel;
        }
    }
}
﻿using GarageManager.Data.Entities;
using GarageManager.Services.Exceptions;
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
        private readonly IMessageBoxService messageBoxService;

        public ShowCustomerDetailsViewCommand(CustomersListViewModel customersListViewModel, ICustomersService customersService, INavigator navigator, IViewModelFactory viewModelFactory, IMessageBoxService messageBoxService)
        {
            this.customersListViewModel = customersListViewModel;
            this.customersService = customersService;
            this.navigator = navigator;
            this.viewModelFactory = viewModelFactory;
            this.messageBoxService = messageBoxService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                Customer customer = await customersService.GetCustomer(customersListViewModel.SelectedCustomer.CustomerId);
                CustomerDetailsViewModel customerDetailsViewModel = (CustomerDetailsViewModel)viewModelFactory.CreateViewModel(ViewType.CustomersDetails);
                customerDetailsViewModel.Customer = customer;
                navigator.CurrentViewModel = customerDetailsViewModel;
            }
            catch (CustomerNotFoundException ex)
            {
                messageBoxService.ShowErrorMessageBox("Error", $"Selected car with ID: {ex.CustomerId} not found.");
            }
            catch (Exception)
            {
                messageBoxService.ShowErrorMessageBox("Error", "An unknown error occurred.");
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !IsExecuting && this.customersListViewModel.SelectedCustomer != null;
        }
    }
}

﻿using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using GarageManager.UI.Infrastructure;
using GarageManager.UI.State.Navigator;
using GarageManager.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.UI.Commands.Cars
{
    public class ShowEditCarViewCommand : BaseAsyncCommand
    {
        private readonly ICustomersService customersService;
        private readonly INavigator navigator;
        private readonly IViewModelFactory viewModelFactory;

        public ShowEditCarViewCommand(ICustomersService customersService, INavigator navigator, IViewModelFactory viewModelFactory)
        {
            this.customersService = customersService;
            this.navigator = navigator;
            this.viewModelFactory = viewModelFactory;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            IEnumerable<Customer> customers = await customersService.GetCustomers();
            EditCarViewModel editCarViewModel = (EditCarViewModel)viewModelFactory.CreateViewModel(ViewType.EditCar);
            editCarViewModel.Customers = customers;
            navigator.CurrentViewModel = editCarViewModel;
        }
    }
}

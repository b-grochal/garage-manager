using GarageManager.Data.Entities;
using GarageManager.Services.Exceptions;
using GarageManager.Services.Interfaces;
using GarageManager.UI.Infrastructure;
using GarageManager.UI.State.Navigator;
using GarageManager.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.UI.Commands.Services
{
    public class ShowEditServiceViewCommand : BaseAsyncCommand
    {
        private readonly ServicesListViewModel servicesListViewModel;
        private readonly IServicesService servicesService;
        private readonly ICarsService carsService;
        private readonly INavigator navigator;
        private readonly IViewModelFactory viewModelFactory;
        private readonly IMessageBoxService messageBoxService;

        public ShowEditServiceViewCommand(ServicesListViewModel servicesListViewModel, IServicesService servicesService, ICarsService carsService, INavigator navigator, IViewModelFactory viewModelFactory, IMessageBoxService messageBoxService)
        {
            this.servicesListViewModel = servicesListViewModel;
            this.servicesService = servicesService;
            this.carsService = carsService;
            this.navigator = navigator;
            this.viewModelFactory = viewModelFactory;
            this.messageBoxService = messageBoxService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                IEnumerable<Car> cars = await carsService.GetCars();
                Service service = await servicesService.GetService(servicesListViewModel.SelectedService.ServiceId);
                EditServiceViewModel editServiceViewModel = (EditServiceViewModel)viewModelFactory.CreateViewModel(ViewType.EditService);
                editServiceViewModel.Service = service;
                editServiceViewModel.Cars = cars;
                navigator.CurrentViewModel = editServiceViewModel;
            }
            catch (ServiceNotFoundException ex)
            {
                messageBoxService.ShowErrorMessageBox("Error", $"Selected service with ID: {ex.ServiceId} not found.");
            }
            catch (Exception)
            {
                messageBoxService.ShowErrorMessageBox("Error", "An unknown error occurred.");
            }
            
        }

        public override bool CanExecute(object parameter)
        {
            return !IsExecuting && this.servicesListViewModel.SelectedService != null;
        }
    }
}

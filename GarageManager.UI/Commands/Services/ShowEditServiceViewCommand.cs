using GarageManager.Data.Entities;
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

        public ShowEditServiceViewCommand(ServicesListViewModel servicesListViewModel, IServicesService servicesService, ICarsService carsService, INavigator navigator, IViewModelFactory viewModelFactory)
        {
            this.servicesListViewModel = servicesListViewModel;
            this.servicesService = servicesService;
            this.carsService = carsService;
            this.navigator = navigator;
            this.viewModelFactory = viewModelFactory;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            IEnumerable<Car> cars = await carsService.GetCars();
            Service service = await servicesService.GetService(servicesListViewModel.SelectedService.ServiceId);
            EditServiceViewModel editServiceViewModel = (EditServiceViewModel)viewModelFactory.CreateViewModel(ViewType.EditService);
            editServiceViewModel.Service = service;
            editServiceViewModel.Cars = cars;
            navigator.CurrentViewModel = editServiceViewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return !IsExecuting && this.servicesListViewModel.SelectedService != null;
        }
    }
}

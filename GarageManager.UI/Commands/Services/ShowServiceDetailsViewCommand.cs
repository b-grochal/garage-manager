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
    public class ShowServiceDetailsViewCommand : BaseAsyncCommand
    {
        private readonly ServicesListViewModel servicesListViewModel;
        private readonly IServicesService servicesService;
        private readonly INavigator navigator;
        private readonly IViewModelFactory viewModelFactory;

        public ShowServiceDetailsViewCommand(ServicesListViewModel servicesListViewModel, IServicesService servicesService, INavigator navigator, IViewModelFactory viewModelFactory)
        {
            this.servicesListViewModel = servicesListViewModel;
            this.servicesService = servicesService;
            this.navigator = navigator;
            this.viewModelFactory = viewModelFactory;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            Service service = await servicesService.GetService(servicesListViewModel.SelectedService.ServiceId);
            ServiceDetailsViewModel serviceDetailsViewModel = (ServiceDetailsViewModel)viewModelFactory.CreateViewModel(ViewType.ServiceDetails);
            serviceDetailsViewModel.Service = service;
            navigator.CurrentViewModel = serviceDetailsViewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return !IsExecuting && this.servicesListViewModel.SelectedService != null;
        }
    }
}

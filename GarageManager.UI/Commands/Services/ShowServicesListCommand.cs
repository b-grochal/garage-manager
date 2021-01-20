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
    public class ShowServicesListCommand : BaseAsyncCommand
    {
        private readonly IServicesService servicesService;
        private readonly INavigator navigator;
        private readonly IViewModelFactory viewModelFactory;

        public ShowServicesListCommand(IServicesService servicesService, INavigator navigator, IViewModelFactory viewModelFactory)
        {
            this.servicesService = servicesService;
            this.navigator = navigator;
            this.viewModelFactory = viewModelFactory;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            IEnumerable<Service> services = await servicesService.GetServices();
            ServicesListViewModel servicesListViewModel = (ServicesListViewModel)viewModelFactory.CreateViewModel(ViewType.ServicesList);
            servicesListViewModel.Services = services;
            navigator.CurrentViewModel = servicesListViewModel;
        }
    }
}

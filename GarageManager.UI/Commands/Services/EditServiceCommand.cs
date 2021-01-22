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
    public class EditServiceCommand : BaseAsyncCommand
    {
        private readonly EditServiceViewModel editServiceViewModel;
        private readonly IServicesService servicesService;
        private readonly INavigator navigator;
        private readonly IViewModelFactory viewModelFactory;

        public EditServiceCommand(EditServiceViewModel editServiceViewModel, IServicesService servicesService, INavigator navigator, IViewModelFactory viewModelFactory)
        {
            this.editServiceViewModel = editServiceViewModel;
            this.servicesService = servicesService;
            this.navigator = navigator;
            this.viewModelFactory = viewModelFactory;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await servicesService.EditService(editServiceViewModel.Service);
            IEnumerable<Service> services = await servicesService.GetServices();
            ServicesListViewModel servicesListViewModel = (ServicesListViewModel)viewModelFactory.CreateViewModel(ViewType.ServicesList);
            servicesListViewModel.Services = services;
            navigator.CurrentViewModel = servicesListViewModel;
        }
    }
}

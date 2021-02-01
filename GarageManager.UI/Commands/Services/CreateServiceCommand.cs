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
    public class CreateServiceCommand : BaseAsyncCommand
    {
        private readonly CreateServiceViewModel createServiceViewModel;
        private readonly IServicesService servicesService;
        private readonly INavigator navigator;
        private readonly IViewModelFactory viewModelFactory;
        private readonly IMessageBoxService messageBoxService;

        public CreateServiceCommand(CreateServiceViewModel createServiceViewModel, IServicesService servicesService, INavigator navigator, IViewModelFactory viewModelFactory, IMessageBoxService messageBoxService)
        {
            this.createServiceViewModel = createServiceViewModel;
            this.servicesService = servicesService;
            this.navigator = navigator;
            this.viewModelFactory = viewModelFactory;
            this.messageBoxService = messageBoxService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            createServiceViewModel.ErrorMessage = string.Empty;

            try
            {
                await servicesService.CreateService(createServiceViewModel.Service);
                IEnumerable<Service> services = await servicesService.GetServices();
                ServicesListViewModel servicesListViewModel = (ServicesListViewModel)viewModelFactory.CreateViewModel(ViewType.ServicesList);
                servicesListViewModel.Services = services;
                navigator.CurrentViewModel = servicesListViewModel;
                messageBoxService.ShowInformationMessageBox("Create service", "Service was successfully created.");
            }
            catch (Exception)
            {
                createServiceViewModel.ErrorMessage = "Failed to create service.";
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !IsExecuting && createServiceViewModel.IsDataValid;
        }
    }
}

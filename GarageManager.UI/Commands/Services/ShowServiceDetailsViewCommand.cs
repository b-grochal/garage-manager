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
    public class ShowServiceDetailsViewCommand : BaseAsyncCommand
    {
        private readonly ServicesListViewModel servicesListViewModel;
        private readonly IServicesService servicesService;
        private readonly INavigator navigator;
        private readonly IViewModelFactory viewModelFactory;
        private readonly IMessageBoxService messageBoxService;

        public ShowServiceDetailsViewCommand(ServicesListViewModel servicesListViewModel, IServicesService servicesService, INavigator navigator, IViewModelFactory viewModelFactory, IMessageBoxService messageBoxService)
        {
            this.servicesListViewModel = servicesListViewModel;
            this.servicesService = servicesService;
            this.navigator = navigator;
            this.viewModelFactory = viewModelFactory;
            this.messageBoxService = messageBoxService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                Service service = await servicesService.GetService(servicesListViewModel.SelectedService.ServiceId);
                ServiceDetailsViewModel serviceDetailsViewModel = (ServiceDetailsViewModel)viewModelFactory.CreateViewModel(ViewType.ServiceDetails);
                serviceDetailsViewModel.Service = service;
                navigator.CurrentViewModel = serviceDetailsViewModel;
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

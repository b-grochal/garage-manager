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
        private readonly IMessageBoxService messageBoxService;

        public EditServiceCommand(EditServiceViewModel editServiceViewModel, IServicesService servicesService, INavigator navigator, IViewModelFactory viewModelFactory, IMessageBoxService messageBoxService)
        {
            this.editServiceViewModel = editServiceViewModel;
            this.servicesService = servicesService;
            this.navigator = navigator;
            this.viewModelFactory = viewModelFactory;
            this.messageBoxService = messageBoxService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            editServiceViewModel.ErrorMessage = string.Empty;

            try
            {
                await servicesService.EditService(editServiceViewModel.Service);
                IEnumerable<Service> services = await servicesService.GetServices();
                ServicesListViewModel servicesListViewModel = (ServicesListViewModel)viewModelFactory.CreateViewModel(ViewType.ServicesList);
                servicesListViewModel.Services = services;
                navigator.CurrentViewModel = servicesListViewModel;
                messageBoxService.ShowInformationMessageBox("Edit service", "Service was successfully edited.");
            }
            catch (Exception)
            {
                editServiceViewModel.ErrorMessage = "Failed to edit service.";
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !IsExecuting && editServiceViewModel.IsDataValid;
        }
    }
}

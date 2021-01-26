using GarageManager.Data.Entities;
using GarageManager.Services.Exceptions;
using GarageManager.Services.Interfaces;
using GarageManager.UI.Infrastructure;
using GarageManager.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.UI.Commands.Services
{
    public class DeleteServiceCommand : BaseAsyncCommand
    {
        private readonly ServicesListViewModel servicesListViewModel;
        private readonly IServicesService servicesService;
        private readonly IMessageBoxService messageBoxService;

        public DeleteServiceCommand(ServicesListViewModel servicesListViewModel, IServicesService servicesService, IMessageBoxService messageBoxService)
        {
            this.servicesListViewModel = servicesListViewModel;
            this.servicesService = servicesService;
            this.messageBoxService = messageBoxService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                bool isDeleteOperationConfirmed = messageBoxService.ShowConfirmationMessageBox("Delete customer", $"Are you sure you want to delete car {servicesListViewModel.SelectedService.Name}?");
                if(isDeleteOperationConfirmed)
                {
                    await servicesService.DeleteService(servicesListViewModel.SelectedService.ServiceId);
                    IEnumerable<Service> services = await servicesService.GetServices();
                    servicesListViewModel.Services = services;
                    messageBoxService.ShowInformationMessageBox("Delete service", "Service was successfully deleted.");
                }
            }
            catch (ServiceNotFoundException ex)
            {
                messageBoxService.ShowErrorMessageBox("Error", $"Selected service with ID: {ex.ServiceId} not found.");
            }
            catch(Exception)
            {
                messageBoxService.ShowErrorMessageBox("Error", "Failed to delete service.");
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !IsExecuting && this.servicesListViewModel.SelectedService != null;
        }
    }
}

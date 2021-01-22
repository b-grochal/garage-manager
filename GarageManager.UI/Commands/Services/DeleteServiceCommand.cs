using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
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

        public DeleteServiceCommand(ServicesListViewModel servicesListViewModel, IServicesService servicesService)
        {
            this.servicesListViewModel = servicesListViewModel;
            this.servicesService = servicesService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await servicesService.DeleteService(servicesListViewModel.SelectedService.ServiceId);
            IEnumerable<Service> services = await servicesService.GetServices();
            servicesListViewModel.Services = services;
        }

        public override bool CanExecute(object parameter)
        {
            return !IsExecuting && this.servicesListViewModel.SelectedService != null;
        }
    }
}

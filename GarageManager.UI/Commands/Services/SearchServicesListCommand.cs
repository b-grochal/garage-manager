using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using GarageManager.UI.Infrastructure;
using GarageManager.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.UI.Commands.Services
{
    public class SearchServicesListCommand : BaseAsyncCommand
    {
        private readonly ServicesListViewModel servicesListViewModel;
        private readonly IServicesService servicesService;
        private readonly IMessageBoxService messageBoxService;

        public SearchServicesListCommand(ServicesListViewModel servicesListViewModel, IServicesService servicesService, IMessageBoxService messageBoxService)
        {
            this.servicesListViewModel = servicesListViewModel;
            this.servicesService = servicesService;
            this.messageBoxService = messageBoxService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                IEnumerable<Service> filteredServices = await servicesService.GetServices(servicesListViewModel.ServicesListSearchCriteria);
                servicesListViewModel.Services = filteredServices;
            }
            catch (Exception)
            {
                messageBoxService.ShowErrorMessageBox("Error", "An unknown error occurred.");
            }
            
        }
    }
}

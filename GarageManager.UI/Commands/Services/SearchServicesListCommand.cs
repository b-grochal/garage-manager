using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
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

        public SearchServicesListCommand(ServicesListViewModel servicesListViewModel, IServicesService servicesService)
        {
            this.servicesListViewModel = servicesListViewModel;
            this.servicesService = servicesService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            IEnumerable<Service> filteredServices = await servicesService.GetServices(servicesListViewModel.ServicesListSearchCriteria);
            servicesListViewModel.Services = filteredServices;
        }
    }
}

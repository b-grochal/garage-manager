using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using GarageManager.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.UI.Commands.Services
{
    public class ResetServicesListSearchCriteriaCommand : BaseAsyncCommand
    {
        private readonly ServicesListViewModel servicesListsViewModel;
        private readonly IServicesService servicesService;

        public ResetServicesListSearchCriteriaCommand(ServicesListViewModel servicesListsViewModel, IServicesService servicesService)
        {
            this.servicesListsViewModel = servicesListsViewModel;
            this.servicesService = servicesService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            servicesListsViewModel.VinSearchCriteria = null;
            IEnumerable<Service> services = await servicesService.GetServices();
            servicesListsViewModel.Services = services;
        }
    }
}

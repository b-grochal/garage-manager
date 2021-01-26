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
    public class ResetServicesListSearchCriteriaCommand : BaseAsyncCommand
    {
        private readonly ServicesListViewModel servicesListsViewModel;
        private readonly IServicesService servicesService;
        private readonly IMessageBoxService messageBoxService;

        public ResetServicesListSearchCriteriaCommand(ServicesListViewModel servicesListsViewModel, IServicesService servicesService, IMessageBoxService messageBoxService)
        {
            this.servicesListsViewModel = servicesListsViewModel;
            this.servicesService = servicesService;
            this.messageBoxService = messageBoxService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                servicesListsViewModel.VinSearchCriteria = null;
                IEnumerable<Service> services = await servicesService.GetServices();
                servicesListsViewModel.Services = services;
            }
            catch (Exception)
            {
                messageBoxService.ShowErrorMessageBox("Error", "An unknown error occurred.");
            }
        }
    }
}

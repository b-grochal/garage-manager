using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using GarageManager.UI.Infrastructure;
using GarageManager.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.UI.Commands.Cars
{
    public class SearchCarsListCommand : BaseAsyncCommand
    {
        private readonly CarsListViewModel carsListViewModel;
        private readonly ICarsService carsService;
        private readonly IMessageBoxService messageBoxService;

        public SearchCarsListCommand(CarsListViewModel carsListViewModel, ICarsService carsService, IMessageBoxService messageBoxService)
        {
            this.carsListViewModel = carsListViewModel;
            this.carsService = carsService;
            this.messageBoxService = messageBoxService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                IEnumerable<Car> filteredCars = await carsService.GetCars(carsListViewModel.CarsListSearchCriteria);
                carsListViewModel.Cars = filteredCars;
            }
            catch (Exception)
            {
                messageBoxService.ShowErrorMessageBox("An unknown error occurred.", "Error");
            }
            
        }
    }
}

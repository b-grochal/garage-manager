using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
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

        public SearchCarsListCommand(CarsListViewModel carsListViewModel, ICarsService carsService)
        {
            this.carsListViewModel = carsListViewModel;
            this.carsService = carsService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            IEnumerable<Car> filteredCars = await carsService.GetCars(carsListViewModel.CarsListSearchCriteria);
            carsListViewModel.Cars = filteredCars;
        }
    }
}

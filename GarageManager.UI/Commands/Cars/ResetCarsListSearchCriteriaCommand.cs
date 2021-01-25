using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using GarageManager.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.UI.Commands.Cars
{
    public class ResetCarsListSearchCriteriaCommand : BaseAsyncCommand
    {
        private readonly CarsListViewModel carsListViewModel;
        private readonly ICarsService carsService;

        public ResetCarsListSearchCriteriaCommand(CarsListViewModel carsListViewModel, ICarsService carsService)
        {
            this.carsListViewModel = carsListViewModel;
            this.carsService = carsService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            carsListViewModel.VinSearchCriteria = null;
            IEnumerable<Car> cars = await carsService.GetCars();
            carsListViewModel.Cars = cars;
        }
    }
}

using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using GarageManager.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.UI.Commands.Cars
{
    public class DeleteCarCommand : BaseAsyncCommand
    {
        private readonly CarsListViewModel carsListViewModel;
        private readonly ICarsService carsService;

        public DeleteCarCommand(CarsListViewModel carsListViewModel, ICarsService carsService)
        {
            this.carsListViewModel = carsListViewModel;
            this.carsService = carsService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await carsService.DeleteCar(carsListViewModel.SelectedCar.CarId);
            IEnumerable<Car> cars = await carsService.GetCars();
            carsListViewModel.Cars = cars;
        }

        public override bool CanExecute(object parameter)
        {
            return !IsExecuting && this.carsListViewModel.SelectedCar!= null;
        }
    }
}

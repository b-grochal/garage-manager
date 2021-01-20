using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using GarageManager.UI.Infrastructure;
using GarageManager.UI.State.Navigator;
using GarageManager.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.UI.Commands.Cars
{
    public class CreateCarCommand : BaseAsyncCommand
    {
        private readonly CreateCarViewModel createCarViewModel;
        private readonly ICarsService carsService;
        private readonly INavigator navigator;
        private readonly IViewModelFactory viewModelFactory;

        public CreateCarCommand(CreateCarViewModel createCarViewModel, ICarsService carsService, INavigator navigator, IViewModelFactory viewModelFactory)
        {
            this.createCarViewModel = createCarViewModel;
            this.carsService = carsService;
            this.navigator = navigator;
            this.viewModelFactory = viewModelFactory;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await carsService.CreateCar(createCarViewModel.Car);
            IEnumerable<Car> cars = await carsService.GetCars();
            CarsListViewModel carsListViewModel = (CarsListViewModel)viewModelFactory.CreateViewModel(ViewType.CarsList);
            carsListViewModel.Cars = cars;
            navigator.CurrentViewModel = carsListViewModel;
        }
    }
}

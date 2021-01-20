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
    public class EditCarCommand : BaseAsyncCommand
    {
        private readonly EditCarViewModel editCarViewModel;
        private readonly ICarsService carsService;
        private readonly INavigator navigator;
        private readonly IViewModelFactory viewModelFactory;

        public EditCarCommand(EditCarViewModel editCarViewModel, ICarsService carsService, INavigator navigator, IViewModelFactory viewModelFactory)
        {
            this.editCarViewModel = editCarViewModel;
            this.carsService = carsService;
            this.navigator = navigator;
            this.viewModelFactory = viewModelFactory;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await carsService.EditCar(editCarViewModel.Car);
            IEnumerable<Car> cars = await carsService.GetCars();
            CarsListViewModel carsListViewModel = (CarsListViewModel)viewModelFactory.CreateViewModel(ViewType.CarsList);
            carsListViewModel.Cars = cars;
            navigator.CurrentViewModel = carsListViewModel;

        }
    }
}

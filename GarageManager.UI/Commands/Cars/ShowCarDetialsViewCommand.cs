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
    public class ShowCarDetialsViewCommand : BaseAsyncCommand
    {
        private readonly CarsListViewModel carsListViewModel;
        private readonly ICarsService carsService;
        private readonly INavigator navigator;
        private readonly IViewModelFactory viewModelFactory;

        public ShowCarDetialsViewCommand(CarsListViewModel carsListViewModel, ICarsService carsService, INavigator navigator, IViewModelFactory viewModelFactory)
        {
            this.carsListViewModel = carsListViewModel;
            this.carsService = carsService;
            this.navigator = navigator;
            this.viewModelFactory = viewModelFactory;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            Car car = await carsService.GetCar(carsListViewModel.SelectedCar.CarId);
            CarDetailsViewModel carDetailsViewModel = (CarDetailsViewModel)viewModelFactory.CreateViewModel(ViewType.CarDetails);
            carDetailsViewModel.Car = car;
            navigator.CurrentViewModel = carDetailsViewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return !IsExecuting && this.carsListViewModel.SelectedCar != null;
        }
    }
}

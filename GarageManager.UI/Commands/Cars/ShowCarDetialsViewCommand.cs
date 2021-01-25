using GarageManager.Data.Entities;
using GarageManager.Services.Exceptions;
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
        private readonly IMessageBoxService messageBoxService;

        public ShowCarDetialsViewCommand(CarsListViewModel carsListViewModel, ICarsService carsService, INavigator navigator, IViewModelFactory viewModelFactory, IMessageBoxService messageBoxService)
        {
            this.carsListViewModel = carsListViewModel;
            this.carsService = carsService;
            this.navigator = navigator;
            this.viewModelFactory = viewModelFactory;
            this.messageBoxService = messageBoxService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                Car car = await carsService.GetCar(carsListViewModel.SelectedCar.CarId);
                CarDetailsViewModel carDetailsViewModel = (CarDetailsViewModel)viewModelFactory.CreateViewModel(ViewType.CarDetails);
                carDetailsViewModel.Car = car;
                navigator.CurrentViewModel = carDetailsViewModel;
            }
            catch (CarNotFoundException ex)
            {
                messageBoxService.ShowErrorMessageBox($"Selected car with ID: {ex.CarId} not found.", "Error");
            }
            catch (Exception)
            {
                messageBoxService.ShowErrorMessageBox("An unknown error occurred.", "Error");
            }

        }

        public override bool CanExecute(object parameter)
        {
            return !IsExecuting && this.carsListViewModel.SelectedCar != null;
        }
    }
}

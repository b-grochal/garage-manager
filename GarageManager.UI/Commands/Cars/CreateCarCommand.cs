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
        private readonly IMessageBoxService messageBoxService;

        public CreateCarCommand(CreateCarViewModel createCarViewModel, ICarsService carsService, INavigator navigator, IViewModelFactory viewModelFactory, IMessageBoxService messageBoxService)
        {
            this.createCarViewModel = createCarViewModel;
            this.carsService = carsService;
            this.navigator = navigator;
            this.viewModelFactory = viewModelFactory;
            this.messageBoxService = messageBoxService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            createCarViewModel.ErrorMessage = string.Empty;

            try
            {
                await carsService.CreateCar(createCarViewModel.Car);
                IEnumerable<Car> cars = await carsService.GetCars();
                CarsListViewModel carsListViewModel = (CarsListViewModel)viewModelFactory.CreateViewModel(ViewType.CarsList);
                carsListViewModel.Cars = cars;
                navigator.CurrentViewModel = carsListViewModel;
                messageBoxService.ShowInformationMessageBox("Create car", "Car was successfully created.");
            }
            catch (Exception)
            {
                createCarViewModel.ErrorMessage = "Failed to create car.";
            }
            
        }

        public override bool CanExecute(object parameter)
        {
            return !IsExecuting && createCarViewModel.IsDataValid;
        }
    }
}

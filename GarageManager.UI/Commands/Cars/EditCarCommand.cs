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
        private readonly IMessageBoxService messageBoxService;

        public EditCarCommand(EditCarViewModel editCarViewModel, ICarsService carsService, INavigator navigator, IViewModelFactory viewModelFactory, IMessageBoxService messageBoxService)
        {
            this.editCarViewModel = editCarViewModel;
            this.carsService = carsService;
            this.navigator = navigator;
            this.viewModelFactory = viewModelFactory;
            this.messageBoxService = messageBoxService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            editCarViewModel.ErrorMessage = string.Empty;

            try
            {
                await carsService.EditCar(editCarViewModel.Car);
                IEnumerable<Car> cars = await carsService.GetCars();
                CarsListViewModel carsListViewModel = (CarsListViewModel)viewModelFactory.CreateViewModel(ViewType.CarsList);
                carsListViewModel.Cars = cars;
                navigator.CurrentViewModel = carsListViewModel;
                messageBoxService.ShowInformationMessageBox("Edit car", "Car was successfully edited.");
            }
            catch (Exception)
            {
                editCarViewModel.ErrorMessage = "Failed to edit car.";
            }
        }
    }
}

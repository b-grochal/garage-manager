using GarageManager.Data.Entities;
using GarageManager.Services.Exceptions;
using GarageManager.Services.Interfaces;
using GarageManager.UI.Infrastructure;
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
        private readonly IMessageBoxService messageBoxService;

        public DeleteCarCommand(CarsListViewModel carsListViewModel, ICarsService carsService, IMessageBoxService messageBoxService)
        {
            this.carsListViewModel = carsListViewModel;
            this.carsService = carsService;
            this.messageBoxService = messageBoxService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                bool isDeleteOperationConfirmed = messageBoxService.ShowConfirmationMessageBox("Delete car", $"Are you sure you want to delete car {carsListViewModel.SelectedCar.Vin}?");
                if(isDeleteOperationConfirmed)
                {
                    await carsService.DeleteCar(carsListViewModel.SelectedCar.CarId);
                    IEnumerable<Car> cars = await carsService.GetCars();
                    carsListViewModel.Cars = cars;
                    messageBoxService.ShowInformationMessageBox("Car was successfully deleted.", "Delete car");
                }
            }
            catch (CarNotFoundException ex)
            {
                messageBoxService.ShowErrorMessageBox($"Selected car with ID: {ex.CarId} not found.", "Error");
            }
            catch (Exception)
            {
                messageBoxService.ShowErrorMessageBox("Failed to delete car.", "Error");
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !IsExecuting && this.carsListViewModel.SelectedCar!= null;
        }
    }
}

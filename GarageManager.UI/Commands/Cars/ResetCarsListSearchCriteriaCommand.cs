using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using GarageManager.UI.Infrastructure;
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
        private readonly IMessageBoxService messageBoxService;

        public ResetCarsListSearchCriteriaCommand(CarsListViewModel carsListViewModel, ICarsService carsService, IMessageBoxService messageBoxService)
        {
            this.carsListViewModel = carsListViewModel;
            this.carsService = carsService;
            this.messageBoxService = messageBoxService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                carsListViewModel.VinSearchCriteria = null;
                IEnumerable<Car> cars = await carsService.GetCars();
                carsListViewModel.Cars = cars;
            }
            catch (Exception)
            {
                messageBoxService.ShowErrorMessageBox("Error", "An unknown error occurred.");
            }
            
        }
    }
}

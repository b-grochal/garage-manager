using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using GarageManager.Services.SearchCriteria;
using GarageManager.UI.Commands.Cars;
using GarageManager.UI.Infrastructure;
using GarageManager.UI.State.Navigator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GarageManager.UI.ViewModels
{
    public class CarsListViewModel : BaseViewModel
    {
        #region Fields

        private IEnumerable<Car> cars;
        private CarsListSearchCriteria carsListSearchCriteria;
        private Car selectedCar;

        #endregion Fields

        #region Properties

        public CarsListSearchCriteria CarsListSearchCriteria
        {
            get
            {
                return this.carsListSearchCriteria;
            }
        }

        public string VinSearchCriteria
        {
            get
            {
                return this.carsListSearchCriteria.Vin;
            }
            set
            {
                this.carsListSearchCriteria.Vin = value;
                OnPropertyChanged(nameof(VinSearchCriteria));
            }
        }

        public IEnumerable<Car> Cars
        {
            get
            {
                return this.cars;
            }
            set
            {
                this.cars = value;
                OnPropertyChanged(nameof(Cars));
            }
        }

        public Car SelectedCar
        {
            get
            {
                return this.selectedCar;
            }
            set
            {
                this.selectedCar = value;
                OnPropertyChanged(nameof(SelectedCar));
            }
        }

        #endregion Properties

        #region Commands

        public ICommand SearchCarsListCommand { get; }
        public ICommand ShowCreateCarViewCommand { get; }
        public ICommand ShowEditCarViewCommand { get; }
        public ICommand ShowCarDetailsViewCommand { get; }
        public ICommand DeleteCarCommand { get; }
        public ICommand ResetCarsListSearchCriteriaCommand { get; }

        #endregion Commands

        #region Constructors

        public CarsListViewModel(ICarsService carsService, ICustomersService customersService, INavigator navigator, IViewModelFactory viewModelFactory, IMessageBoxService messageBoxService)
        {
            this.carsListSearchCriteria = new CarsListSearchCriteria();
            this.SearchCarsListCommand = new SearchCarsListCommand(this, carsService, messageBoxService);
            this.ShowCreateCarViewCommand = new ShowCreateCarViewCommand(customersService, navigator, viewModelFactory, messageBoxService);
            this.ShowEditCarViewCommand = new ShowEditCarViewCommand(this, carsService, customersService, navigator, viewModelFactory, messageBoxService);
            this.ShowCarDetailsViewCommand = new ShowCarDetialsViewCommand(this, carsService, navigator, viewModelFactory, messageBoxService);
            this.DeleteCarCommand = new DeleteCarCommand(this, carsService, messageBoxService);
            this.ResetCarsListSearchCriteriaCommand = new ResetCarsListSearchCriteriaCommand(this, carsService, messageBoxService);

        }

        #endregion Cnstructors
    }
}

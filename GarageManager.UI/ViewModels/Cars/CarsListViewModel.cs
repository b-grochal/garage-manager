using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using GarageManager.Services.SearchCriteria;
using GarageManager.UI.Infrastructure;
using GarageManager.UI.State.Navigator;
using System;
using System.Collections.Generic;
using System.Text;

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
                return this.carsListSearchCriteria.VIN;
            }
            set
            {
                this.carsListSearchCriteria.VIN = value;
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

        #endregion Commands

        #region Constructors

        public CarsListViewModel(ICarsService carsService, INavigator navigator, IViewModelFactory viewModelFactory)
        {
            this.carsListSearchCriteria = new CarsListSearchCriteria();
        }

        #endregion Cnstructors
    }
}

using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using GarageManager.UI.Commands.Cars;
using GarageManager.UI.Infrastructure;
using GarageManager.UI.State.Navigator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GarageManager.UI.ViewModels
{
    public class EditCarViewModel : BaseViewModel
    {
        #region Fields

        private Car car;
        private IEnumerable<Customer> customers;

        #endregion Fields

        #region ViewModels

        public MessageViewModel ErrorMessageViewModel { get; }

        #endregion ViewModels

        #region Properties

        public Car Car
        {
            get
            {
                return this.car;
            }
            set
            {
                this.car = value;
            }
        }

        public string Brand
        {
            get
            {
                return this.car.Brand;
            }
            set
            {
                this.car.Brand = value;
                OnPropertyChanged(nameof(Brand));
            }
        }

        public string Model
        {
            get
            {
                return this.car.Model;
            }
            set
            {
                this.car.Model = value;
                OnPropertyChanged(nameof(Model));
            }
        }

        public string VIN
        {
            get
            {
                return this.car.VIN;
            }
            set
            {
                this.car.VIN = value;
                OnPropertyChanged(nameof(VIN));
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.car.RegistrationNumber;
            }
            set
            {
                this.car.RegistrationNumber = value;
                OnPropertyChanged(nameof(RegistrationNumber));
            }
        }

        public string FuelType
        {
            get
            {
                return this.car.FuelType;
            }
            set
            {
                this.car.FuelType = value;
                OnPropertyChanged(nameof(FuelType));
            }
        }

        public string Engine
        {
            get
            {
                return this.car.Engine;
            }
            set
            {
                this.car.Engine = value;
                OnPropertyChanged(nameof(Engine));
            }
        }
        public string Transmission
        {
            get
            {
                return this.car.Transmission;
            }
            set
            {
                this.car.Transmission = value;
                OnPropertyChanged(nameof(Transmission));
            }
        }

        public int CustomerId
        {
            get
            {
                return this.car.CustomerId;
            }
            set
            {
                this.car.CustomerId = value;
                OnPropertyChanged(nameof(CustomerId));
            }
        }

        public IEnumerable<Customer> Customers
        {
            get
            {
                return this.customers;
            }
            set
            {
                this.customers = value;
            }
        }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        #endregion Properties

        #region Commands

        public ICommand EditCarCommand { get; }

        #endregion Commands

        #region Constructors

        public EditCarViewModel(ICarsService carsService, INavigator navigator, IViewModelFactory viewModelFactory)
        {
            this.ErrorMessageViewModel = new MessageViewModel();
            this.EditCarCommand = new EditCarCommand(this, carsService, navigator, viewModelFactory);
        }

        #endregion Constructors
    }
}

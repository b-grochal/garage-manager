using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using GarageManager.UI.Commands.Cars;
using GarageManager.UI.Infrastructure;
using GarageManager.UI.State.Navigator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace GarageManager.UI.ViewModels
{
    public class CreateCarViewModel : BaseViewModel, IDataErrorInfo
    {
        #region Fields

        private Car car;
        private IEnumerable<Customer> customers;
        private IDictionary<string, string> dataErrorsDictionary;

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

        public string Vin
        {
            get
            {
                return this.car.Vin;
            }
            set
            {
                this.car.Vin = value;
                OnPropertyChanged(nameof(Vin));
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

        public string Error => throw new NotImplementedException();

        public IDictionary<string, string> DataErrorsDictionary
        {
            get
            {
                return this.dataErrorsDictionary;
            }
            private set
            {
                this.dataErrorsDictionary = value;
            }
        }

        public bool IsDataValid
        {
            get
            {
                foreach (KeyValuePair<string, string> item in dataErrorsDictionary)
                {
                    if (item.Value != null)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        #endregion Properties

        #region Indexers

        public string this[string propertyName]
        {
            get
            {
                string result = null;

                switch (propertyName)
                {
                    case nameof(Brand):
                        if (string.IsNullOrWhiteSpace(Brand))
                            result = "Brand cannot be empty.";
                        break;
                    case nameof(Model):
                        if (string.IsNullOrWhiteSpace(Model))
                            result = "Model cannot be empty.";
                        break;
                    case nameof(Vin):
                        if (string.IsNullOrWhiteSpace(Vin))
                            result = "Vin cannot be empty.";
                        break;
                    case nameof(RegistrationNumber):
                        if (string.IsNullOrWhiteSpace(RegistrationNumber))
                            result = "Registration number cannot be empty.";
                        break;
                    case nameof(FuelType):
                        if (string.IsNullOrWhiteSpace(FuelType))
                            result = "Fuel type cannot be empty.";
                        break;
                    case nameof(Engine):
                        if (string.IsNullOrWhiteSpace(Engine))
                            result = "Engine cannot be empty.";
                        break;
                    case nameof(Transmission):
                        if (string.IsNullOrWhiteSpace(Transmission))
                            result = "Transmission cannot be empty.";
                        break;
                    case nameof(CustomerId):
                        if (CustomerId == 0)
                            result = "Customer has to be selected.";
                        break;
                }

                if (DataErrorsDictionary.ContainsKey(propertyName))
                    DataErrorsDictionary[propertyName] = result;
                else
                    DataErrorsDictionary.Add(propertyName, result);

                OnPropertyChanged(nameof(DataErrorsDictionary));
                return result;
            }
        }

        #endregion Indexers

        #region Commands

        public ICommand CreateCarCommand { get; }

        #endregion Commands

        #region Constructors

        public CreateCarViewModel(ICarsService carsService, INavigator navigator, IViewModelFactory viewModelFactory, IMessageBoxService messageBoxService)
        {
            this.DataErrorsDictionary = new Dictionary<string, string>();
            this.car = new Car();
            this.ErrorMessageViewModel = new MessageViewModel();
            this.CreateCarCommand = new CreateCarCommand(this, carsService, navigator, viewModelFactory, messageBoxService);
        }

        #endregion Constructors
    }
}

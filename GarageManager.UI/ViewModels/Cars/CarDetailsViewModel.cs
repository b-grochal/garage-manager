using GarageManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.UI.ViewModels
{
    public class CarDetailsViewModel : BaseViewModel
    {
        #region Fields

        private Car car;
        private Service selectedService;

        #endregion Fields

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

        public string Model
        {
            get
            {
                return this.car.Model;
            }
        }

        public string Brand
        {
            get
            {
                return this.car.Brand;
            }
        }

        public string Vin
        {
            get
            {
                return this.car.Vin;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.car.RegistrationNumber;
            }
        }

        public string FuelType
        {
            get
            {
                return this.car.FuelType;
            }
        }

        public string Engine
        {
            get
            {
                return this.car.Engine;
            }
        }

        public string Transmission
        {
            get
            {
                return this.car.Transmission;
            }
        }

        public string Owner
        {
            get
            {
                return this.car.Customer.FullName;
            }
        }

        public IEnumerable<Service> CarServices
        {
            get
            {
                return this.car.Services;
            }
        }

        public Service SelectedService
        {
            get
            {
                return this.selectedService;
            }
            set
            {
                this.selectedService = value;
                OnPropertyChanged(nameof(SelectedService));
            }
        }

        #endregion Properties

        #region Constructors

        public CarDetailsViewModel()
        {

        }

        #endregion Constructors
    }
}

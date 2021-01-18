using GarageManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.UI.ViewModels
{
    public class CustomerDetailsViewModel : BaseViewModel
    {
        #region Fields

        private Customer customer;
        private Car selectedCustomerCar;

        #endregion Fields

        #region Properties

        public Customer Customer
        {
            get
            {
                return this.customer;
            }
            set
            {
                this.customer = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.customer.FirstName;
            }
            set
            {
                this.customer.FirstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get
            {
                return this.customer.LastName;
            }
            set
            {
                this.customer.LastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.customer.PhoneNumber;
            }
            set
            {
                this.customer.PhoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }
        public string Email
        {
            get
            {
                return this.customer.Email;
            }
            set
            {
                this.customer.Email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public IEnumerable<Car> CustomerCars
        {
            get
            {
                return this.customer.Cars;
            }
        }

        public Car SelectedCustomerCar
        {
            get
            {
                return this.selectedCustomerCar;
            }
            set
            {
                this.selectedCustomerCar = value;
                OnPropertyChanged(nameof(SelectedCustomerCar));
            }
        }

        #endregion Properties

        #region Constructors

        public CustomerDetailsViewModel()
        {

        }

        #endregion Constructors
    }
}

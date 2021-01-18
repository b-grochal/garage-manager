using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using GarageManager.UI.Commands;
using GarageManager.UI.Infrastructure;
using GarageManager.UI.State.Navigator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GarageManager.UI.ViewModels
{
    public class CreateCustomerViewModel : BaseViewModel
    {
        #region Fields

        private Customer customer;

        #endregion Fields

        #region ViewModels

        public MessageViewModel ErrorMessageViewModel { get; }

        #endregion ViewModels

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
                this.customer.FirstName= value;
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

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        #endregion Properties

        #region Commands

        public ICommand CreateCustomerCommand { get; }

        #endregion Commands

        #region Constructors

        public CreateCustomerViewModel(ICustomersService customersService, INavigator navigator, IViewModelFactory viewModelFactory)
        {
            this.Customer = new Customer();
            this.CreateCustomerCommand = new CreateCustomerCommand(this, customersService, navigator, viewModelFactory);
            this.ErrorMessageViewModel = new MessageViewModel();
        }

        #endregion Constructors
    }
}

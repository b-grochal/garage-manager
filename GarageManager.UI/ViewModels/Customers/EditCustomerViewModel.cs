using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using GarageManager.UI.Commands;
using GarageManager.UI.Infrastructure;
using GarageManager.UI.State.Navigator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace GarageManager.UI.ViewModels
{
    public class EditCustomerViewModel : BaseViewModel, IDataErrorInfo
    {
        #region Fields

        private Customer customer;
        private Dictionary<string, string> dataErrorsDictionary;

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

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public string Error => throw new NotImplementedException();

        public Dictionary<string, string> DataErrorsDictionary
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
                    case nameof(FirstName):
                        if (string.IsNullOrWhiteSpace(FirstName))
                            result = "First name cannot be empty.";
                        break;
                    case nameof(LastName):
                        if (string.IsNullOrWhiteSpace(LastName))
                            result = "Last name cannot be empty.";
                        break;
                    case nameof(PhoneNumber):
                        if (string.IsNullOrWhiteSpace(PhoneNumber))
                            result = "Last name cannot be empty.";
                        break;
                    case nameof(Email):
                        if (string.IsNullOrWhiteSpace(Email))
                            result = "Last name cannot be empty.";
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

        public ICommand EditCustomerCommand { get; }

        #endregion Commands

        #region Constructors

        public EditCustomerViewModel(ICustomersService customersService, INavigator navigator, IViewModelFactory viewModelFactory, IMessageBoxService messageBoxService)
        {
            this.DataErrorsDictionary = new Dictionary<string, string>();
            this.EditCustomerCommand = new EditCustomerCommand(this, customersService, navigator, viewModelFactory, messageBoxService);
            this.ErrorMessageViewModel = new MessageViewModel();
        }

        #endregion Constructors
    }
}

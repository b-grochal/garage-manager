using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using GarageManager.Services.SearchCriteria;
using GarageManager.UI.Commands;
using GarageManager.UI.Commands.Customers;
using GarageManager.UI.Infrastructure;
using GarageManager.UI.State.Navigator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GarageManager.UI.ViewModels
{
    public class CustomersListViewModel : BaseViewModel
    {
        #region Fields

        private CustomersListSearchCriteria customersListSearchCriteria;
        private IEnumerable<Customer> customers;
        private Customer selectedCustomer;

        #endregion Fields

        #region Properties

        public CustomersListSearchCriteria CustomersListSearchCriteria
        {
            get
            {
                return customersListSearchCriteria;
            }
        }

        public string FirstNameSearchCirteria
        {
            get
            {
                return this.customersListSearchCriteria.FirstName;
            }
            set
            {
                this.customersListSearchCriteria.FirstName= value;
                OnPropertyChanged(nameof(FirstNameSearchCirteria));
            }
        }

        public string LastNameSearchCirteria
        {
            get
            {
                return this.customersListSearchCriteria.FirstName;
            }
            set
            {
                this.customersListSearchCriteria.FirstName = value;
                OnPropertyChanged(nameof(FirstNameSearchCirteria));
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
                OnPropertyChanged(nameof(Customers));
            }
        }

        public Customer SelectedCustomer
        {
            get
            {
                return this.selectedCustomer;
            }
            set
            {
                this.selectedCustomer = value;
                OnPropertyChanged(nameof(SelectedCustomer));
            }
        }

        #endregion Properties

        #region Commands

        public ICommand SearchCustomersListCommand { get; }
        public ICommand ShowCreateCustomerViewCommand { get; }
        public ICommand ShowEditCustomerViewCommand { get; }
        public ICommand ShowCustomerDetailsViewCommand { get; }
        public ICommand DeleteCustomerCommand { get; }
        public ICommand ResetCustomersListSearchCriteriaCommand { get; }

        #endregion Commands

        #region Constructors

        public CustomersListViewModel(ICustomersService customersService, INavigator navigator, IViewModelFactory viewModelFactory)
        {
            this.customersListSearchCriteria = new CustomersListSearchCriteria();
            this.SearchCustomersListCommand = new SearchCustomersListCommand(this, customersService);
            this.ShowCreateCustomerViewCommand = new ShowCreateCustomerViewCommand(navigator, viewModelFactory);
            this.ShowEditCustomerViewCommand = new ShowEditCustomerViewCommand(this, customersService, navigator, viewModelFactory);
            this.ShowCustomerDetailsViewCommand = new ShowCustomerDetailsViewCommand(this, customersService, navigator, viewModelFactory);
            this.DeleteCustomerCommand = new DeleteCustomerCommand(this, customersService);
            this.ResetCustomersListSearchCriteriaCommand = new ResetCustomersListSearchCriteriaCommand(this, customersService);
        }

        #endregion Constructors
    }
}

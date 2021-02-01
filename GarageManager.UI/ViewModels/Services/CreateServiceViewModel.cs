using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using GarageManager.UI.Commands.Services;
using GarageManager.UI.Infrastructure;
using GarageManager.UI.State.Navigator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace GarageManager.UI.ViewModels
{
    public class CreateServiceViewModel : BaseViewModel, IDataErrorInfo
    {
        #region Fields

        private Service service;
        private IEnumerable<Car> cars;
        private IDictionary<string, string> dataErrorsDictionary;

        #endregion Fields

        #region ViewModels 

        public MessageViewModel ErrorMessageViewModel { get;  }

        #endregion ViewModels

        #region Properties

        public Service Service
        {
            get
            {
                return this.service;
            }
            set
            {
                this.service = value;
            }
        }

        public string Name
        {
            get
            {
                return this.service.Name;
            }
            set
            {
                this.service.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Description
        {
            get
            {
                return this.service.Description;
            }
            set
            {
                this.service.Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public decimal Cost
        {
            get
            {
                return this.service.Cost;
            }
            set
            {
                this.service.Cost = value;
                OnPropertyChanged(nameof(Cost));
            }
        }

        public DateTime Date
        {
            get
            {
                return this.service.DateOfService;
            }
            set
            {
                this.service.DateOfService = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        public int CarId
        {
            get
            {
                return this.service.CarId;
            }
            set
            {
                this.service.CarId = value;
                OnPropertyChanged(nameof(CarId));
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
                    case nameof(Name):
                        if (string.IsNullOrWhiteSpace(Name))
                            result = "Name cannot be empty.";
                        break;
                    case nameof(Description):
                        if (string.IsNullOrWhiteSpace(Description))
                            result = "Description cannot be empty.";
                        break;
                    case nameof(Cost):
                        if (Cost <= 0)
                            result = "Invalid cost value.";
                        break;
                    case nameof(CarId):
                        if (CarId == 0)
                            result = "Car has to be selected.";
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

        public ICommand CreateServiceCommand { get; }

        #endregion Commands

        #region Constructors

        public CreateServiceViewModel(IServicesService servicesService, INavigator navigator, IViewModelFactory viewModelFactory, IMessageBoxService messageBoxService)
        {
            this.DataErrorsDictionary = new Dictionary<string, string>();
            this.service = new Service();
            this.Date = DateTime.Now;
            this.ErrorMessageViewModel = new MessageViewModel();
            this.CreateServiceCommand = new CreateServiceCommand(this, servicesService, navigator, viewModelFactory, messageBoxService);
        }

        #endregion Constructors
    }
}

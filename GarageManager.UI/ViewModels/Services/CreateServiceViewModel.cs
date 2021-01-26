using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using GarageManager.UI.Commands.Services;
using GarageManager.UI.Infrastructure;
using GarageManager.UI.State.Navigator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GarageManager.UI.ViewModels
{
    public class CreateServiceViewModel : BaseViewModel
    {
        #region Fields

        private Service service;
        private IEnumerable<Car> cars;

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

        #endregion Properties

        #region Commands

        public ICommand CreateServiceCommand { get; }

        #endregion Commands

        #region Constructors

        public CreateServiceViewModel(IServicesService servicesService, INavigator navigator, IViewModelFactory viewModelFactory, IMessageBoxService messageBoxService)
        {
            this.service = new Service();
            this.Date = DateTime.Now;
            this.ErrorMessageViewModel = new MessageViewModel();
            this.CreateServiceCommand = new CreateServiceCommand(this, servicesService, navigator, viewModelFactory, messageBoxService);
        }

        #endregion Constructors
    }
}

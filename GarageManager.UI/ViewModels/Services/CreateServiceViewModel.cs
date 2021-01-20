using GarageManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.UI.ViewModels.Services
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
                return this.service.Cosr;
            }
            set
            {
                this.service.Cosr = value;
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

        #endregion Commands

        #region Constructors

        public CreateServiceViewModel()
        {
            this.service = new Service();
            this.ErrorMessageViewModel = new MessageViewModel();
        }

        #endregion Constructors
    }
}

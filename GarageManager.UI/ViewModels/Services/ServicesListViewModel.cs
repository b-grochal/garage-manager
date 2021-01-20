using GarageManager.Data.Entities;
using GarageManager.Services.SearchCriteria;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.UI.ViewModels.Services
{
    public class ServicesListViewModel : BaseViewModel
    {
        #region Fields

        private IEnumerable<Service> services;
        private ServicesListSearchCriteria servicesListSearchCriteria;
        private Service selectedService;

        #endregion Fields

        #region Properties

        public ServicesListSearchCriteria ServicesListSearchCriteria
        {
            get
            {
                return this.servicesListSearchCriteria;
            }
        }

        public string VinSearchCriteria
        {
            get
            {
                return this.servicesListSearchCriteria.Vin;
            }
            set
            {
                this.servicesListSearchCriteria.Vin = value;
                OnPropertyChanged(nameof(VinSearchCriteria));
            }
        }

        public IEnumerable<Service> Services
        {
            get
            {
                return this.services;
            }
            set
            {
                this.services = value;
                OnPropertyChanged(nameof(Services));
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

        #region Commands

        #endregion Commands

        #region Constructors

        public ServicesListViewModel()
        {

        }

        #endregion Constructors

    }
}

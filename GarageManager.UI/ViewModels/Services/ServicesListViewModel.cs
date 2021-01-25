using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using GarageManager.Services.SearchCriteria;
using GarageManager.UI.Commands.Services;
using GarageManager.UI.Infrastructure;
using GarageManager.UI.State.Navigator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GarageManager.UI.ViewModels
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

        public ICommand SearchServicesListCommand { get; }
        public ICommand ShowCreateServiceViewCommand { get; }
        public ICommand ShowEditServiceViewCommand { get; }
        public ICommand ShowServiceDetailsViewCommand { get; }
        public ICommand DeleteServiceCommand { get; }
        public ICommand ResetServicesListSearchCriteriaCommand { get; }

        #endregion Commands

        #region Constructors

        public ServicesListViewModel(IServicesService servicesService, ICarsService carsService, INavigator navigator, IViewModelFactory viewModelFactory)
        {
            this.servicesListSearchCriteria = new ServicesListSearchCriteria();
            this.SearchServicesListCommand = new SearchServicesListCommand(this, servicesService);
            this.ShowCreateServiceViewCommand = new ShowCreateServiceViewCommand(carsService, navigator, viewModelFactory);
            this.ShowEditServiceViewCommand = new ShowEditServiceViewCommand(this, servicesService, carsService, navigator, viewModelFactory);
            this.ShowServiceDetailsViewCommand = new ShowServiceDetailsViewCommand(this, servicesService, navigator, viewModelFactory);
            this.DeleteServiceCommand = new DeleteServiceCommand(this, servicesService);
            this.ResetServicesListSearchCriteriaCommand = new ResetServicesListSearchCriteriaCommand(this, servicesService);
        }

        #endregion Constructors

    }
}

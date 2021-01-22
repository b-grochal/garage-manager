using GarageManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.UI.ViewModels
{
    public class ServiceDetailsViewModel : BaseViewModel
    {
        #region Fields

        private Service service;

        #endregion Fields

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
        }

        public string Description
        {
            get
            {
                return this.service.Description;
            }
        }

        public decimal Cost
        {
            get
            {
                return this.service.Cosr;
            }
        }

        public DateTime Date
        {
            get
            {
                return this.service.DateOfService;
            }
        }

        #endregion Properties

        #region Constructors

        public ServiceDetailsViewModel()
        {

        }

        #endregion Constructors
    }
}

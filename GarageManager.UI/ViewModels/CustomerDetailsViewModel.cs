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

        #endregion Properties
    }
}

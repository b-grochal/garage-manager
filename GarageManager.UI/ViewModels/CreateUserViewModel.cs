using GarageManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.UI.ViewModels
{
    public class CreateUserViewModel : BaseViewModel
    {
        #region Fields

        private User user;
        private string password;

        #endregion Fields

        #region Properties

        public User User
        {
            get
            {
                return this.user;
            }
        }

        public string UserName
        {
            get
            {
                return this.user.UserName;
            }
            set
            {
                this.user.UserName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        #endregion Properties

        #region Commands

        #endregion Commands
    }
}

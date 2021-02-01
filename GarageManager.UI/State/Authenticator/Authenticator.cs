using GarageManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.UI.State.Authenticator
{
    public class Authenticator : IAuthenticator
    {
        private User loggedUser;
        public User LoggedUser
        {
            get
            {
                return this.loggedUser;
            }
            set
            {
                this.loggedUser = value;
                StateChanged?.Invoke();
            }
        }

        public bool IsLoggedIn => LoggedUser != null;

        public event Action StateChanged;

        public void Login(User user)
        {
            LoggedUser = user; 
        }

        public void Logout()
        {
            LoggedUser = null;
        }
    }
}

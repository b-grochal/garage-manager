using GarageManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.UI.State.Authenticator
{
    public class Authenticator : IAuthenticator
    {
        private User _loggedUser;
        public User LoggedUser
        {
            get
            {
                return this._loggedUser;
            }
            set
            {
                this._loggedUser = value;
                StateChanged?.Invoke();
            }
        }

        public bool IsLoggedIn => LoggedUser != null;

        public event Action StateChanged;

        public Task Login(string login, string password)
        {
            LoggedUser = new User
            {
                UserId = 1,
                UserName = "Jack",
                PasswordHash = "hdkasjskjc385qncauey8q4"
            };
            return null;
        }

        public void Logout()
        {
            LoggedUser = null;
        }
    }
}

using GarageManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.UI.State.Authenticator
{
    public class Authenticator : IAuthenticator
    {
        public User LoggedUser => throw new NotImplementedException();

        public bool IsLoggedIn => throw new NotImplementedException();

        public event Action StateChanged;

        public Task Login(string login, string password)
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}

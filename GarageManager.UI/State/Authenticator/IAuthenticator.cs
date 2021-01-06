using GarageManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.UI.State.Authenticator
{
    public interface IAuthenticator
    {
        User LoggedUser{ get; }
        bool IsLoggedIn { get; }

        event Action StateChanged;

        Task Login(string login, string password);

        void Logout();
    }
}

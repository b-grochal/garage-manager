using GarageManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User> Login(string login, string password);
    }
}

using GarageManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.Services.Interfaces
{
    public interface IUsersService 
    {
        Task<IEnumerable<User>> GetUsers();
        Task DeleteUser(int userId);
        Task CreateUser(User user);
    }
}

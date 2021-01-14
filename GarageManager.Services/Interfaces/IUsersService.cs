using GarageManager.Data.Entities;
using GarageManager.Services.SearchCriteria;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.Services.Interfaces
{
    public interface IUsersService 
    {
        Task<IEnumerable<User>> GetUsers();
        Task<IEnumerable<User>> GetUsers(UsersListSearchCriteria usersListSearchCriteria);
        Task DeleteUser(int userId);
        Task CreateUser(User user, string password, string confirmPassword);
    }
}

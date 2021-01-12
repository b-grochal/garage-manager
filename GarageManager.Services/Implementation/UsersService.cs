using GarageManager.Data.Context;
using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using GarageManager.Services.SearchCriteria;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.Services.Implementation
{
    public class UsersService : IUsersService
    {
        private readonly GarageManagerDbContext _garageManagerDbContext;

        public UsersService(GarageManagerDbContext garageManagerDbContext)
        {
            this._garageManagerDbContext = garageManagerDbContext;
        }

        public Task CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _garageManagerDbContext.Users
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetUsers(UsersListSearchCriteria usersListSearchCriteria)
        {
            var queryable = _garageManagerDbContext.Users.AsQueryable();

            if (!string.IsNullOrEmpty(usersListSearchCriteria.Login))
            {
                queryable = queryable.Where(u => u.UserName.Contains(usersListSearchCriteria.Login));
            }

            return await queryable.ToListAsync();
        }
    }
}

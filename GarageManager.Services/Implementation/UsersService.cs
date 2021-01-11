using GarageManager.Data.Context;
using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    }
}

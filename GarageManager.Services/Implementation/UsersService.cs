using GarageManager.Data.Context;
using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using GarageManager.Services.SearchCriteria;
using Microsoft.AspNetCore.Identity;
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
        private readonly GarageManagerDbContext garageManagerDbContext;
        private readonly IPasswordHasher<User> passwordHasher;

        public UsersService(GarageManagerDbContext garageManagerDbContext, IPasswordHasher<User> passwordHasher)
        {
            this.garageManagerDbContext = garageManagerDbContext;
            this.passwordHasher = passwordHasher;
        }

        public async Task CreateUser(User user, string password)
        {
            string passwordHash = passwordHasher.HashPassword(user, password);
            user.PasswordHash = passwordHash;
            await garageManagerDbContext.Users.AddAsync(user);
            await garageManagerDbContext.SaveChangesAsync();
        }

        public Task DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await garageManagerDbContext.Users.ToListAsync();
        }

        public async Task<IEnumerable<User>> GetUsers(UsersListSearchCriteria usersListSearchCriteria)
        {
            var queryable = garageManagerDbContext.Users.AsQueryable();

            if (!string.IsNullOrEmpty(usersListSearchCriteria.Login))
            {
                queryable = queryable.Where(u => u.UserName.Contains(usersListSearchCriteria.Login));
            }

            return await queryable.ToListAsync();
        }
    }
}

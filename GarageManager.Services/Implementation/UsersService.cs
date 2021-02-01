using GarageManager.Data.Context;
using GarageManager.Data.Entities;
using GarageManager.Services.Exceptions;
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
        private readonly GarageManagerDbContextFactory contextFactory;
        private readonly IPasswordHasher<User> passwordHasher;

        public UsersService(GarageManagerDbContextFactory contextFactory, IPasswordHasher<User> passwordHasher)
        {
            this.contextFactory = contextFactory;
            this.passwordHasher = passwordHasher;
        }

        public async Task CreateUser(User user, string password)
        {
            using (GarageManagerDbContext context = contextFactory.CreateDbContext())
            {
                string passwordHash = passwordHasher.HashPassword(user, password);
                user.PasswordHash = passwordHash;
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteUser(int userId)
        {
            using (GarageManagerDbContext context = contextFactory.CreateDbContext())
            {
                var user = context.Users.Find(userId);

                if (user == null)
                {
                    throw new UserNotFoundException(userId);
                }

                context.Users.Remove(user);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            using (GarageManagerDbContext context = contextFactory.CreateDbContext())
            {
                return await context.Users.ToListAsync();
            }
        }

        public async Task<IEnumerable<User>> GetUsers(UsersListSearchCriteria usersListSearchCriteria)
        {
            using (GarageManagerDbContext context = contextFactory.CreateDbContext())
            {
                var queryable = context.Users.AsQueryable();

                if (!string.IsNullOrEmpty(usersListSearchCriteria.Login))
                {
                    queryable = queryable.Where(u => u.UserName.Contains(usersListSearchCriteria.Login));
                }

                return await queryable.ToListAsync();
            }
        }
    }
}

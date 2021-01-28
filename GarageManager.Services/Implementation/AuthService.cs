using GarageManager.Data.Context;
using GarageManager.Data.Entities;
using GarageManager.Services.Exceptions;
using GarageManager.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly GarageManagerDbContextFactory contextFactory;
        private readonly IPasswordHasher<User> passwordHasher;

        public AuthService(GarageManagerDbContextFactory context, IPasswordHasher<User> passwordHasher)
        {
            this.contextFactory = context;
            this.passwordHasher = passwordHasher;
        }

        public async Task<User> Login(string userName, string password)
        {
            using(GarageManagerDbContext context = contextFactory.CreateDbContext())
            {
                User user = await context.Users.FirstOrDefaultAsync(u => u.UserName == userName);

                if (user == null)
                {
                    throw new InvalidUserNameException(userName);
                }

                PasswordVerificationResult passwordResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);

                if (passwordResult != PasswordVerificationResult.Success)
                {
                    throw new InvalidPasswordException(userName);
                }

                return user;
            }
        }
    }
}

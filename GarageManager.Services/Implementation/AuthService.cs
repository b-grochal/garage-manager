using GarageManager.Data.Context;
using GarageManager.Data.Entities;
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
        private readonly GarageManagerDbContext _garageManagerDbContext;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthService(GarageManagerDbContext garageManagerDbContext, IPasswordHasher<User> passwordHasher)
        {
            this._garageManagerDbContext = garageManagerDbContext;
            this._passwordHasher = passwordHasher;
        }

        public async Task<User> Login(string userName, string password)
        {
            User user = await _garageManagerDbContext.Users.FirstOrDefaultAsync(u => u.UserName == userName);

            if (user == null)
            {
                //throw new UserNotFoundException(username);
                throw new Exception();
            }

            PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);

            if (passwordResult != PasswordVerificationResult.Success)
            {
                //throw new InvalidPasswordException(username, password);
                throw new Exception();
            }

            //return storedAccount;
            return user;
        }
    }
}

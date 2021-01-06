using GarageManager.Data.Context;
using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly GarageManagerDbContext _garageManagerDbContext;

        public AuthService(GarageManagerDbContext garageManagerDbContext)
        {
            this._garageManagerDbContext = garageManagerDbContext;
        }

        public async Task<User> Login(string login, string password)
        {
            //User user = await _garageManagerDbContext.Users.Find(u => );

            //if (storedAccount == null)
            //{
            //    throw new UserNotFoundException(username);
            //}

            //PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword(storedAccount.AccountHolder.PasswordHash, password);

            //if (passwordResult != PasswordVerificationResult.Success)
            //{
            //    throw new InvalidPasswordException(username, password);
            //}

            //return storedAccount;
            return new User
            {
                UserId = 1,
                UserName = "Jack",
                PasswordHash = "2384327823496327238937532cbjsdhbcsj"
            };
        }
    }
}

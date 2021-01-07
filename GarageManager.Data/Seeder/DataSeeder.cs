using GarageManager.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.Data.Seeder
{
    public static class DataSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var passwordHasher = new PasswordHasher<User>();
            var newUser = new User
            {
                UserId = 1,
                UserName = "Admin",
            };
            var hashedPassword = passwordHasher.HashPassword(newUser, "admin");
            newUser.PasswordHash = hashedPassword;
            modelBuilder.Entity<User>().HasData(newUser);
        }
    }
}

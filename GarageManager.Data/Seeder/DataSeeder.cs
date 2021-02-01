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
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            User user = new User
            {
                UserId = 1,
                UserName = "Admin",
            };
            string hashedPassword = passwordHasher.HashPassword(user, "P@ssw0rd");
            user.PasswordHash = hashedPassword;
            modelBuilder.Entity<User>().HasData(user);
        }
    }
}

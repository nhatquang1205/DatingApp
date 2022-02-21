using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DatingApp.API.Database.Entities;
using DatingApp.API.DTOs;

namespace DatingApp.API.Database
{
    public class Seed
    {
        public static void SeedUser(DataContext context)
        {
            if(context.Users.Any()) return;

            var userData = System.IO.File.ReadAllText("Database/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<User>>(userData);
            if(users == null)
            {
                return;
            }

            foreach(var user in users)
            {
                user.Username.ToLower();
                using var hmac = new HMACSHA512();

                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd"));
                user.PasswordSalt = hmac.Key;
                user.CreatedAt = DateTime.Now;
                context.Users.Add(user);
            }
            context.SaveChanges();
        }
    }
}
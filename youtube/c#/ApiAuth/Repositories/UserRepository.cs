using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAuth.Models;

namespace ApiAuth.Repositories
{
    public static class UserRepository
    {
        public static User Get(string userName, string password)
        {
            var users = new List<User>
            {
                new() {Id = 1, UserName = "batman", Password = "batman", Role = "manager"},
                new() {Id = 1, UserName = "robin", Password = "robin", Role = "employee"}
            };

            return users
                .FirstOrDefault(x =>
                   string.Equals(x.UserName, userName, StringComparison.CurrentCultureIgnoreCase)
                   && x.Password == password);
        }
    }
}
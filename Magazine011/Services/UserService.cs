using System;
using System.Collections.Generic;
using System.Linq;
using Magazine011.Data;
using Magazine011.Models;

namespace Magazine011.Services
{
    public class UserService : IUserService
    {
        public List<User> Users => Seeder.SeedMe();

        public User GetUserById(string id)
        {
             return Seeder.SeedMe().FirstOrDefault(x => x.Id == id);
        }
    }
}


/*
 
 public List<User> Users {
            get {
                return Seeder.SeedMe();
            }
            private set { }
        }
 
 
 */
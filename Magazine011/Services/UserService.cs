using System;
using System.Collections.Generic;
using Magazine011.Data;
using Magazine011.Models;

namespace Magazine011.Services
{
    public class UserService : IUserService
    {
        public List<User> Users {
            get {
                return Seeder.SeedMe();
            }
            private set { }
        }
    }
}

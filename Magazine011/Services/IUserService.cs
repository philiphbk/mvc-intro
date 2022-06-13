using System.Collections.Generic;
using Magazine011.Models;

namespace Magazine011.Services
{
    public interface IUserService
    {
        public List<User> Users { get; }
        public User GetUserById(string id);
    }
}
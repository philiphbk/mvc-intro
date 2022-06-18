using System;
using System.Collections.Generic;
using System.Linq;
using Magazine011.Data;
using Magazine011.Data.Repository;
using Magazine011.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Magazine011.Services
{
    public class UserService : IUserService
    {
        public List<User> Users { get; private set; }
        public List<UserForDB> UsersFromDB { get; private set; }

        private readonly IConfiguration _config;
        private readonly IRepository _repo;

        public UserService(IConfiguration config, IRepository repository)
        {
            
            Users = Seeder.ReadMe(config);
            UsersFromDB = GetUsersFromDB();
            _config = config;
            _repo = repository;
        }

        private List<UserForDB> GetUsersFromDB()
        {
            var res = _repo.FetchData("SELECT * FROM Persons");
            if (res.HasRows)
            {
                var results = new List<UserForDB>();
                while (res.NextResult())
                {
                    results.Add(
                        new UserForDB()
                        {
                            Id = res.GetInt32(0),
                            FirstName = res.GetString(1),
                            LastName = res.GetString(2),
                        }
                    );
                }
                return results;
            }
            else
            {
                return new List<UserForDB>();
            }
        }

        public User GetUserById(string id)
        {
             return Seeder.ReadMe(_config).FirstOrDefault(x => x.Id == id);
        }

        public bool UpdateUser(User user)
        {
            foreach(var member in Users)
            {
                if(member.Id == user.Id)
                {
                    member.Name = user.Name;
                    member.Password = user.Password;
                    member.Role = user.Role;
                    member.Photo = user.Photo;
                }
            }

            // write users to json
            return Seeder.WriteMe(Users, _config);

        }

        public User GetUserByEmail(string email)
        {
            return Seeder.ReadMe(_config).FirstOrDefault(x => x.Email == email);
        }

        public string AddUser(User user)
        {
            var userId = Guid.NewGuid().ToString();

            user.Id = userId;

            Users.Add(user);

            // write to the json file using seeder
            Seeder.WriteMe(Users, _config);


            return userId;

        }

        public string AddUserToDB(UserForDB user)
        {
            var stmt = "INSERT INTO Persons (FirstName, LastName)";
            stmt += $"VALUES('{user.FirstName}', '{user.LastName}')";

            // add to DB
            _repo.ExecuteQuery(stmt);
            
            return "";
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
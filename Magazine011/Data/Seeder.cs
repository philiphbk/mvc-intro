using System;
using System.Collections.Generic;
using System.IO;
using Magazine011.Models;
using Newtonsoft.Json;

namespace Magazine011.Data
{
    public class Seeder
    {
        public Seeder()
        {
        }

        public static List<User> SeedMe()
        {
            var data = File.ReadAllText("Data/ClassMembers.json");

            var users = JsonConvert.DeserializeObject<List<User>>(data);

            return users;
        }
    }
}

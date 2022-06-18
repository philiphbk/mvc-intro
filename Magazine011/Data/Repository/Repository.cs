using System;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Magazine011.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly string _conStr;

        public Repository(IConfiguration configure)
        {
            _conStr = configure.GetSection("DBCon:Path").Value ;
            
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_conStr) ;
        }

        public bool ExecuteQuery(string statement)
        {
            var con = GetConnection();
            try
            {
                con.Open();
                using (var cmd = new SqlCommand(statement,con))
                {
                    var res = cmd.ExecuteNonQuery();
                    if (res > 0)
                        return true;
                    else
                        return false;
                }
            }
            finally
            {
                con.Close();
            }

        }

        public SqlDataReader FetchData(string statement)
        {
            var con = GetConnection();
            try
            {
                con.Open();
                using (var cmd = new SqlCommand(statement, con))
                {
                    var res = cmd.ExecuteReader();
                    return res;
                }
            }
            finally
            {
                con.Close();
            }

        }
    }
}

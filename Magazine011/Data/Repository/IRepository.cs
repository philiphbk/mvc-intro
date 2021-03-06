using Microsoft.AspNetCore.Connections;
using System.Data.SqlClient;

namespace Magazine011.Data.Repository
{
    public interface IRepository
    {
      
        public bool ExecuteQuery(string statement);
        public SqlConnection GetConnection();
        public SqlDataReader FetchData(string statement);
    }
}

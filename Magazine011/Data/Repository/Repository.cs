using Microsoft.Extensions.Configuration;

namespace Magazine011.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly string _conStr;

        public Repository(IConfiguration configure)
        {
            _conStr =  ;
            
        }

        public bool ExecuteQuery(string statement)
        {
            throw new System.NotImplementedException();
        }

                
    }
}

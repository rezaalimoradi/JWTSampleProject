using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace Infrastructure.Common
{
    public interface IConnectionUtility
    {
        SqlConnection GetConfigDbConneciton();
    }
    public class ConnectionUtility : IConnectionUtility
    {
        private readonly Configs configs;
        public ConnectionUtility(IOptions<Configs> options)
        {
            this.configs = options.Value;
        }
        public SqlConnection GetConfigDbConneciton()
        {
            return new SqlConnection(configs.DBConnection);
        }


    }
}

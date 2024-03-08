using Microsoft.Extensions.Configuration;
using PackageGroup.Ecommerce.Transversal.Common;
using System.Data;
using System.Data.SqlClient;

namespace PackageGroup.Ecommerce.Infrastructure.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        public readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection
        {
            get
            {
                var connectionString = _configuration.GetConnectionString("NorthwindConnection");
                var sqlConnection = new SqlConnection(connectionString);

                if (sqlConnection is null) return null;
                sqlConnection.Open();

                return sqlConnection;
            }
        }
    }
}

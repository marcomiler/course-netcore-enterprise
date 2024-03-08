using Dapper;
using PackageGroup.Ecommerce.Domain.Entity;
using PackageGroup.Ecommerce.Infrastructure.Interface;
using PackageGroup.Ecommerce.Transversal.Common;
using System.Data;

namespace PackageGroup.Ecommerce.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public UserRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public User Authenticate(string userName, string password)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UsersGetByUserAndPassword";
                var parameters = new DynamicParameters();
                parameters.Add("UserName", userName);
                parameters.Add("Password", password);

                var user = connection.QuerySingle<User>(query, parameters, commandType: CommandType.StoredProcedure);
                return user;
            }
        }
    }
    
}

using Dapper;
using PackageGroup.Ecommerce.Domain.Entity;
using PackageGroup.Ecommerce.Infrastructure.Data;
using PackageGroup.Ecommerce.Infrastructure.Interface;
using System.Data;

namespace PackageGroup.Ecommerce.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _context;

        public UserRepository(DapperContext context)
        {
            _context = context;
        }

        public User Authenticate(string userName, string password)
        {
            using (var connection = _context.CreateConnection())
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

using Dapper;
using PackageGroup.Ecommerce.Domain.Entity;
using PackageGroup.Ecommerce.Infrastructure.Data;
using PackageGroup.Ecommerce.Infrastructure.Interface;
using System.Data;

namespace PackageGroup.Ecommerce.Infrastructure.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DapperContext _context;
        public CategoryRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            using var connection = _context.CreateConnection();
            var query = "SELECT * FROM Categories";

            var categories = await connection.QueryAsync<Category>(
                    query,
                    commandType: CommandType.Text
                );

            return categories;
        }
    }
}

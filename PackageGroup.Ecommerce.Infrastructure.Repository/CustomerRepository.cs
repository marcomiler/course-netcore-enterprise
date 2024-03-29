using Dapper;
using PackageGroup.Ecommerce.Domain.Entity;
using PackageGroup.Ecommerce.Infrastructure.Data;
using PackageGroup.Ecommerce.Infrastructure.Interface;
using System.Data;

namespace PackageGroup.Ecommerce.Infrastructure.Repository
{
    public class CustomerRepository : ICustomersRepository
    {
        private readonly DapperContext _context;

        public CustomerRepository(DapperContext context)
        {
            _context = context;
        }

        #region Síncronos
        public bool Insert(Customers customer)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomersInsert";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerId", customer.CustomerId);
                parameters.Add("CompanyName", customer.CompanyName);
                parameters.Add("ContactName", customer.ContactName);
                parameters.Add("ContactTitle", customer.ContactTitle);
                parameters.Add("Address", customer.Address);
                parameters.Add("City", customer.City);
                parameters.Add("Region", customer.Region);
                parameters.Add("PostalCode", customer.PostalCode);
                parameters.Add("Country", customer.Country);
                parameters.Add("Phone", customer.Phone);
                parameters.Add("Fax", customer.Fax);

                var result = connection.Execute(query, parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        public bool Update(Customers customer)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomersUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerId", customer.CustomerId);
                parameters.Add("CompanyName", customer.CompanyName);
                parameters.Add("ContactName", customer.ContactName);
                parameters.Add("ContactTitle", customer.ContactTitle);
                parameters.Add("Address", customer.Address);
                parameters.Add("City", customer.City);
                parameters.Add("Region", customer.Region);
                parameters.Add("PostalCode", customer.PostalCode);
                parameters.Add("Country", customer.Country);
                parameters.Add("Phone", customer.Phone);
                parameters.Add("Fax", customer.Fax);

                var result = connection.Execute(
                    query,
                    parameters,
                    commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        public bool Delete(string customerId)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomerDelete";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customerId);

                var result = connection.Execute(
                    query,
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure);
                return result > 0;
            }
        }
        public Customers Get(string customerId)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomersGetById";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customerId);

                var result = connection.QuerySingle<Customers>(
                    query,
                    parameters,
                    commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public IEnumerable<Customers> GetAll()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomersList";
                var customers = connection.Query<Customers>(
                    query,
                    commandType: CommandType.StoredProcedure);

                return customers;
            }
        }
        public IEnumerable<Customers> GetAllWithPagination(int pageNumber, int pageSize)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomersListWithPagination";

                var parameters = new DynamicParameters();
                parameters.Add("PageNumber", pageNumber);
                parameters.Add("PageSize", pageSize);

                var customers = connection.Query<Customers>(
                    query,
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return customers;
            }
        }

        public int Count()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "SELECT COUNT(*) FROM Customers";

                var count = connection.ExecuteScalar<int>(
                    query,
                    commandType: CommandType.Text);

                return count;
            }
        }
        #endregion



        #region Asíncronos
        public async Task<bool> InsertAsync(Customers customer)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomersInsert";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerId", customer.CustomerId);
                parameters.Add("CompanyName", customer.CompanyName);
                parameters.Add("ContactName", customer.ContactName);
                parameters.Add("ContactTitle", customer.ContactTitle);
                parameters.Add("Address", customer.Address);
                parameters.Add("City", customer.City);
                parameters.Add("Region", customer.Region);
                parameters.Add("PostalCode", customer.PostalCode);
                parameters.Add("Country", customer.Country);
                parameters.Add("Phone", customer.Phone);
                parameters.Add("Fax", customer.Fax);

                var result = await connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }
        public async Task<bool> UpdateAsync(Customers customer)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomersUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerId", customer.CustomerId);
                parameters.Add("CompanyName", customer.CompanyName);
                parameters.Add("ContactName", customer.ContactName);
                parameters.Add("ContactTitle", customer.ContactTitle);
                parameters.Add("Address", customer.Address);
                parameters.Add("City", customer.City);
                parameters.Add("Region", customer.Region);
                parameters.Add("PostalCode", customer.PostalCode);
                parameters.Add("Country", customer.Country);
                parameters.Add("Phone", customer.Phone);
                parameters.Add("Fax", customer.Fax);

                var result = await connection.ExecuteAsync(
                    query,
                    parameters,
                    commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        public async Task<bool> DeleteAsync(string customerId)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomersDelete";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customerId);

                var result = await connection.ExecuteAsync(
                    query,
                    parameters,
                    commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        public async Task<Customers> GetAsync(string customerId)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomersGetById";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customerId);

                var result = await connection.QuerySingleAsync<Customers>(
                    query,
                    parameters,
                    commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomersList";

                var customers = await connection.QueryAsync<Customers>(
                    query,
                    commandType: CommandType.StoredProcedure);
                return customers;
            }
        }
        public async Task<IEnumerable<Customers>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomersListWithPagination";

                var parameters = new DynamicParameters();
                parameters.Add("PageNumber", pageNumber);
                parameters.Add("PageSize", pageSize);

                var customers = await connection.QueryAsync<Customers>(
                    query,
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return customers;
            }
        }

        public async Task<int> CountAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "SELECT COUNT(*) FROM Customers";

                var count = await connection.ExecuteScalarAsync<int>(
                    query,
                    commandType: CommandType.Text);

                return count;
            }
        }

        #endregion
    }
}

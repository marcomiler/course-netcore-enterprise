using System.Data;

namespace PackageGroup.Ecommerce.Transversal.Common
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection {  get; }
    }
}

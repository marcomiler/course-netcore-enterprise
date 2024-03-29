using PackageGroup.Ecommerce.Domain.Entity;

namespace PackageGroup.Ecommerce.Domain.Interface
{
    public interface ICategoryDomain
    {
        Task<IEnumerable<Category>> GetAll();
    }
}

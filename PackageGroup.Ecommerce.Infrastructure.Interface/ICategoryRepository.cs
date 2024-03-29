using PackageGroup.Ecommerce.Domain.Entity;

namespace PackageGroup.Ecommerce.Infrastructure.Interface
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAll();
    }
}

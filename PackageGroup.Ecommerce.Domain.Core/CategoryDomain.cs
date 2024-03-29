using PackageGroup.Ecommerce.Domain.Entity;
using PackageGroup.Ecommerce.Domain.Interface;
using PackageGroup.Ecommerce.Infrastructure.Interface;

namespace PackageGroup.Ecommerce.Domain.Core
{
    public class CategoryDomain : ICategoryDomain
    {
        private readonly IUnifOfWork _unifOfWork;

        public CategoryDomain(IUnifOfWork unifOfWork)
        {
            _unifOfWork = unifOfWork;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _unifOfWork.CategoryRepository.GetAll();
        }
    }
}

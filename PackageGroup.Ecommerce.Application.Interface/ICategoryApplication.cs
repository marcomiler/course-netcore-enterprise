using PackageGroup.Ecommerce.Application.DTO;
using PackageGroup.Ecommerce.Transversal.Common;

namespace PackageGroup.Ecommerce.Application.Interface
{
    public interface ICategoryApplication
    {
        Task<Response<IEnumerable<CategoryDTO>>> GetAll();
    }
}

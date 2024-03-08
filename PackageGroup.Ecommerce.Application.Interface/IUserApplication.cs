using PackageGroup.Ecommerce.Application.DTO;
using PackageGroup.Ecommerce.Transversal.Common;

namespace PackageGroup.Ecommerce.Application.Interface
{
    public interface IUserApplication
    {
        Response<UserDTO> Authenticate(string username, string password);
    }
}

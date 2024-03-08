using PackageGroup.Ecommerce.Domain.Entity;

namespace PackageGroup.Ecommerce.Infrastructure.Interface
{
    public interface IUserRepository
    {
        User Authenticate(string userName, string password);
    }
}

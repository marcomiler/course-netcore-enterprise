using PackageGroup.Ecommerce.Domain.Entity;

namespace PackageGroup.Ecommerce.Domain.Interface
{
    public interface IUserDomain
    {
        User Authenticate(string username, string password);
    }
}

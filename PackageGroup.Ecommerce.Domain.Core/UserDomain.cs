using PackageGroup.Ecommerce.Domain.Entity;
using PackageGroup.Ecommerce.Domain.Interface;
using PackageGroup.Ecommerce.Infrastructure.Interface;

namespace PackageGroup.Ecommerce.Domain.Core
{
    public class UserDomain : IUserDomain
    {
        private readonly IUserRepository _userRepository;

        public UserDomain(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Authenticate(string username, string password)
        {
            return _userRepository.Authenticate(username, password);
        }
    }
}

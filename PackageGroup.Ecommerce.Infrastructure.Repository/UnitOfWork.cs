using PackageGroup.Ecommerce.Infrastructure.Interface;

namespace PackageGroup.Ecommerce.Infrastructure.Repository
{
    public class UnitOfWork : IUnifOfWork
    {
        public ICustomersRepository CustomersRepository { get; }
        public IUserRepository UserRepository { get; }

        public UnitOfWork(
            ICustomersRepository customersRepository,
            IUserRepository userRepository
        )
        {
            CustomersRepository = customersRepository;
            UserRepository = userRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize( this );
        }
    }
}

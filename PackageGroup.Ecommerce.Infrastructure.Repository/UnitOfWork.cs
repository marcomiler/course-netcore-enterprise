using PackageGroup.Ecommerce.Infrastructure.Interface;

namespace PackageGroup.Ecommerce.Infrastructure.Repository
{
    public class UnitOfWork : IUnifOfWork
    {
        public ICustomersRepository CustomersRepository { get; }
        public IUserRepository UserRepository { get; }

        public ICategoryRepository CategoryRepository { get; }

        public UnitOfWork(
            ICustomersRepository customersRepository,
            IUserRepository userRepository,
            ICategoryRepository categoryRepository
        )
        {
            CustomersRepository = customersRepository;
            UserRepository = userRepository;
            CategoryRepository = categoryRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize( this );
        }
    }
}

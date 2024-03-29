namespace PackageGroup.Ecommerce.Infrastructure.Interface
{
    public interface IUnifOfWork : IDisposable
    {
        ICustomersRepository CustomersRepository { get; }
        IUserRepository UserRepository { get; }
    }
}

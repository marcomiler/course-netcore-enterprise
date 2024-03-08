using PackageGroup.Ecommerce.Domain.Entity;
using PackageGroup.Ecommerce.Domain.Interface;
using PackageGroup.Ecommerce.Infrastructure.Interface;

namespace PackageGroup.Ecommerce.Domain.Core
{
    public class CustomersDomain : ICustomerDomain
    {
        private readonly ICustomersRepository _customersRepository;
        public CustomersDomain(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        //AQUI ES DONDE SE APLICA LA LÓGICA DE NEGOCIO
        #region Síncronos
        public bool Insert(Customers customer)
        {
            return _customersRepository.Insert(customer);
        }
        public bool Update(Customers customer)
        {
            return _customersRepository.Update(customer);
        }
        public bool Delete(string customerId)
        {
            return _customersRepository.Delete(customerId);
        }
        public Customers Get(string customerId)
        {
            return _customersRepository.Get(customerId);
        }
        public IEnumerable<Customers> GetAll()
        {
            return _customersRepository.GetAll();
        }
        #endregion


        #region Asíncronos
        public async Task<bool> InsertAsync(Customers customer)
        {
            return await _customersRepository.InsertAsync(customer);
        }
        public async Task<bool> UpdateAsync(Customers customer)
        {
            return await _customersRepository.UpdateAsync(customer);
        }
        public async Task<bool> DeleteAsync(string customerId)
        {
            return await _customersRepository.DeleteAsync(customerId);
        }
        public async Task<Customers> GetAsync(string customerId)
        {
            return await _customersRepository.GetAsync(customerId);
        }
        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            return await _customersRepository.GetAllAsync();
        }
        #endregion
    }
}

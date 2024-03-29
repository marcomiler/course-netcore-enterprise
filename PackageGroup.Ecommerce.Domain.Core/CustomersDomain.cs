using PackageGroup.Ecommerce.Domain.Entity;
using PackageGroup.Ecommerce.Domain.Interface;
using PackageGroup.Ecommerce.Infrastructure.Interface;

namespace PackageGroup.Ecommerce.Domain.Core
{
    public class CustomersDomain : ICustomerDomain
    {
        private readonly IUnifOfWork _unitOfWork;
        public CustomersDomain(IUnifOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //AQUI ES DONDE SE APLICA LA LÓGICA DE NEGOCIO
        #region Síncronos
        public bool Insert(Customers customer)
        {
            return _unitOfWork.CustomersRepository.Insert(customer);
        }
        public bool Update(Customers customer)
        {
            return _unitOfWork.CustomersRepository.Update(customer);
        }
        public bool Delete(string customerId)
        {
            return _unitOfWork.CustomersRepository.Delete(customerId);
        }
        public Customers Get(string customerId)
        {
            return _unitOfWork.CustomersRepository.Get(customerId);
        }
        public IEnumerable<Customers> GetAll()
        {
            return _unitOfWork.CustomersRepository.GetAll();
        }
        public IEnumerable<Customers> GetAllWithPagination(int pageNumber, int pageSize)
        {
            return _unitOfWork.CustomersRepository.GetAllWithPagination(pageNumber, pageSize);
        }

        public int Count()
        {
            return _unitOfWork.CustomersRepository.Count();
        }
        #endregion


        #region Asíncronos
        public async Task<bool> InsertAsync(Customers customer)
        {
            return await _unitOfWork.CustomersRepository.InsertAsync(customer);
        }
        public async Task<bool> UpdateAsync(Customers customer)
        {
            return await _unitOfWork.CustomersRepository.UpdateAsync(customer);
        }
        public async Task<bool> DeleteAsync(string customerId)
        {
            return await _unitOfWork.CustomersRepository.DeleteAsync(customerId);
        }
        public async Task<Customers> GetAsync(string customerId)
        {
            return await _unitOfWork.CustomersRepository.GetAsync(customerId);
        }
        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            return await _unitOfWork.CustomersRepository.GetAllAsync();
        }        

        public async Task<IEnumerable<Customers>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            return await _unitOfWork.CustomersRepository.GetAllWithPaginationAsync(pageNumber, pageSize);
        }

        public async Task<int> CountAsync()
        {
            return await _unitOfWork.CustomersRepository.CountAsync();
        }
        #endregion
    }
}

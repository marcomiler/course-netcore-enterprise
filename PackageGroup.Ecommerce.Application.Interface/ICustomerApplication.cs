using PackageGroup.Ecommerce.Application.DTO;
using PackageGroup.Ecommerce.Transversal.Common;

namespace PackageGroup.Ecommerce.Application.Interface
{
    public interface ICustomerApplication
    {
        #region Síncronos
        Response<bool> Insert(CustomerDTO customerDto);
        Response<bool> Update(CustomerDTO customerDto);
        Response<bool> Delete(string customerId);
        Response<CustomerDTO> Get(string customerId);
        Response<IEnumerable<CustomerDTO>> GetAll();
        #endregion


        #region Asíncronos
        Task<Response<bool>> InsertAsync(CustomerDTO customerDto);
        Task<Response<bool>> UpdateAsync(CustomerDTO customerDto);
        Task<Response<bool>> DeleteAsync(string customerId);
        Task<Response<CustomerDTO>> GetAsync(string customerId);
        Task<Response<IEnumerable<CustomerDTO>>> GetAllAsync();
        #endregion
    }
}

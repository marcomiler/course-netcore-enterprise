using AutoMapper;
using PackageGroup.Ecommerce.Application.DTO;
using PackageGroup.Ecommerce.Application.Interface;
using PackageGroup.Ecommerce.Domain.Entity;
using PackageGroup.Ecommerce.Domain.Interface;
using PackageGroup.Ecommerce.Transversal.Common;

namespace PackageGroup.Ecommerce.Application.Main
{
    public class CustomerApplication : ICustomerApplication
    {
        private readonly ICustomersDomain _customerDomain;
        private readonly IMapper _mapper;

        public CustomerApplication(ICustomersDomain customerDomain, IMapper mapper)
        {
            _customerDomain = customerDomain;
            _mapper = mapper;
        }

        public Response<bool> Insert(CustomerDTO customerDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customerDto);
                response.Data = _customerDomain.Insert(customer);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!!!";
                }

            } catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
        public Response<bool> Update(CustomerDTO customerDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customerDto);
                response.Data = _customerDomain.Update(customer);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitosa!!!";
                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
        public Response<bool> Delete(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = _customerDomain.Delete(customerId);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa!!!";
                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
        public Response<CustomerDTO> Get(string customerId)
        {
            var response = new Response<CustomerDTO>();
            try
            {
                var customer = _customerDomain.Get(customerId);
                response.Data = _mapper.Map<CustomerDTO>(customer);

                if (response.Data is not null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
        public Response<IEnumerable<CustomerDTO>> GetAll()
        {
            var response = new Response<IEnumerable<CustomerDTO>>();
            try
            {
                var customers = _customerDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<CustomerDTO>>(customers);

                if (response.Data is not null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }


        public async Task<Response<bool>> InsertAsync(CustomerDTO customerDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customerDto);
                response.Data = await _customerDomain.InsertAsync(customer);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!!!";
                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
        public async Task<Response<bool>> UpdateAsync(CustomerDTO customerDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customerDto);
                response.Data = await _customerDomain.UpdateAsync(customer);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitosa!!!";
                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
        public async Task<Response<bool>> DeleteAsync(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _customerDomain.DeleteAsync(customerId);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa!!!";
                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
        public async Task<Response<CustomerDTO>> GetAsync(string customerId)
        {
            var response = new Response<CustomerDTO>();
            try
            {
                var customer = await _customerDomain.GetAsync(customerId);
                response.Data = _mapper.Map<CustomerDTO>(customer);

                if (response.Data is not null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
        public async Task<Response<IEnumerable<CustomerDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CustomerDTO>>();
            try
            {
                var customers = await _customerDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<CustomerDTO>>(customers);

                if (response.Data is not null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}

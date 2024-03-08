using AutoMapper;
using PackageGroup.Ecommerce.Application.DTO;
using PackageGroup.Ecommerce.Application.Interface;
using PackageGroup.Ecommerce.Domain.Interface;
using PackageGroup.Ecommerce.Transversal.Common;

namespace PackageGroup.Ecommerce.Application.Main
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserDomain _usersDomain;
        private readonly IMapper _mapper;

        public UserApplication(IUserDomain usersDomain, IMapper mapper)
        {
            _usersDomain = usersDomain;
            _mapper = mapper;
        }
        public Response<UserDTO> Authenticate(string username, string password)
        {
            var response = new Response<UserDTO>();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                response.Message = "Parámetros no pueden ser vacíos";
                return response;
            }

            try
            {
                var user = _usersDomain.Authenticate(username, password);
                response.Data = _mapper.Map<UserDTO>(user);
                response.IsSuccess = true;
                response.Message = "Authenticación Exitosa!!!";
            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = true;
                response.Message = "Usuario no existe";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                throw;
            }

            return response;
        }
    }
}

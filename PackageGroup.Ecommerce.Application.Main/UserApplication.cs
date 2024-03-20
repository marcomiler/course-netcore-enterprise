using AutoMapper;
using PackageGroup.Ecommerce.Aplication.Validator;
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
        private readonly UserDtoValidator _userDtoValidator;

        public UserApplication(
            IUserDomain usersDomain,
            IMapper mapper,
            UserDtoValidator userDtoValidator
        )
        {
            _usersDomain = usersDomain;
            _mapper = mapper;
            _userDtoValidator = userDtoValidator;
        }
        public Response<UserDTO> Authenticate(string username, string password)
        {
            var response = new Response<UserDTO>();
            var validation = _userDtoValidator.Validate(new UserDTO
            {
                UserName = username,
                Password = password
            });

            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
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

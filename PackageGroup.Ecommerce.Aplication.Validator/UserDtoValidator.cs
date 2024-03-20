using FluentValidation;
using PackageGroup.Ecommerce.Application.DTO;

namespace PackageGroup.Ecommerce.Aplication.Validator
{
    public class UserDtoValidator : AbstractValidator<UserDTO>
    {
        public UserDtoValidator()
        {
            RuleFor(u => u.UserName).NotNull().NotEmpty();
            RuleFor(u => u.Password).NotNull().NotEmpty();
        }
    }
}

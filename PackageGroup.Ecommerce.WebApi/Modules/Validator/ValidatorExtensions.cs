using PackageGroup.Ecommerce.Aplication.Validator;

namespace PackageGroup.Ecommerce.WebApi.Modules.Validator
{
    public static class ValidatorExtensions
    {
        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            //crea una nueva instancia de la clase UserDtoValidator por cada petición
            services.AddTransient<UserDtoValidator>();
            return services;
        }
    }
}

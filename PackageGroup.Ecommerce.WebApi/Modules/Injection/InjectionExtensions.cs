using PackageGroup.Ecommerce.Application.Interface;
using PackageGroup.Ecommerce.Application.Main;
using PackageGroup.Ecommerce.Domain.Core;
using PackageGroup.Ecommerce.Domain.Interface;
using PackageGroup.Ecommerce.Infrastructure.Data;
using PackageGroup.Ecommerce.Infrastructure.Interface;
using PackageGroup.Ecommerce.Infrastructure.Repository;
using PackageGroup.Ecommerce.Transversal.Common;
using PackageGroup.Ecommerce.Transversal.Logging;

namespace PackageGroup.Ecommerce.WebApi.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();

            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<ICustomerApplication, CustomerApplication>();

            services.AddScoped<IUserDomain, UserDomain>();
            services.AddScoped<ICustomerDomain, CustomersDomain>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICustomersRepository, CustomerRepository>();

            //SE DEFINE ASÍ PORQUE ES UNA CLASE GENÉRICA
            services.AddScoped(typeof(IAppLoger<>), typeof(LoggerAdapter<>));

            return services;
        }
    }
}

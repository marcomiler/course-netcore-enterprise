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
            services.AddSingleton<DapperContext>();

            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<ICustomerApplication, CustomerApplication>();
            services.AddScoped<ICategoryApplication, CategoryApplication>();

            services.AddScoped<IUserDomain, UserDomain>();
            services.AddScoped<ICustomerDomain, CustomersDomain>();
            services.AddScoped<ICategoryDomain, CategoryDomain>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICustomersRepository, CustomerRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            //SE DEFINE ASÍ PORQUE ES UNA CLASE GENÉRICA
            services.AddScoped(typeof(IAppLoger<>), typeof(LoggerAdapter<>));
            services.AddScoped<IUnifOfWork, UnitOfWork>();

            return services;
        }
    }
}

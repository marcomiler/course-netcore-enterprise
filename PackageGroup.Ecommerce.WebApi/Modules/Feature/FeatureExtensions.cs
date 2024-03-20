using Microsoft.AspNetCore.Mvc;

namespace PackageGroup.Ecommerce.WebApi.Modules.Feature
{
    public static class FeatureExtensions
    {
        public static IServiceCollection AddFeature(this IServiceCollection services, IConfiguration configuration)
        {
            var myPolicy = "policyApiEcommerce";

            services.AddCors(opt =>
            {
                opt.AddPolicy(myPolicy, b =>
                {
                    b.WithOrigins(configuration["Config:OriginCors"])
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Latest);

            return services;
        }
    }
}

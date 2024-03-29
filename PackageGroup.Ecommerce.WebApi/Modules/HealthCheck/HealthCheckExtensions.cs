using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace PackageGroup.Ecommerce.WebApi.Modules.HealthCheck
{
    public static class HealthCheckExtensions
    {
        public static IServiceCollection AddHealthCheck(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddSqlServer(
                    configuration["ConnectionStrings:NorthwindConnection"],
                    healthQuery: "select 1",
                    name: "SQL Server",
                    failureStatus: HealthStatus.Unhealthy,
                    tags: new[] { "database" })
                .AddCheck<HealthCheckCustom>(
                    "HealthCheckCustom",
                    tags: new[] { "custom" })

                //Redis:
                .AddRedis(
                    configuration.GetConnectionString("RedisConnection"),
                    tags: new[] { "cache" });

            services.AddHealthChecksUI(opt =>
            {
                opt.SetEvaluationTimeInSeconds(5);
                opt.MaximumHistoryEntriesPerEndpoint(60);
                opt.SetApiMaxActiveRequests(1);
            })
            .AddInMemoryStorage();

            return services;
        }
    }
}

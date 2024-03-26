using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace PackageGroup.Ecommerce.WebApi.Modules.HealthCheck
{
    public class HealthCheckCustom : IHealthCheck
    {
        private readonly Random _random = new();
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            //Simulando: aqui podriamos llamar por ejemplo:
            //1. un servicio de mensajeria para monitorear el tiempo de respuesta
            //2. un servicio remoto
            var responseTime = _random.Next(1, 300);

            if (responseTime < 100)
            {
                return Task.FromResult(HealthCheckResult.Healthy("Healthly result from HealthCheckCustom"));
            }
            else if (responseTime < 200)
            {
                return Task.FromResult(HealthCheckResult.Degraded("Degraded result from HealthCheckCustom"));
            }

            return Task.FromResult(HealthCheckResult.Unhealthy("Unhealthy result from HealthCheckCustom"));
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackageGroup.Ecommerce.Application.Interface;
using PackageGroup.Ecommerce.WebApi.Modules.Injection;

namespace PackageGroup.Ecommerce.Application.Test
{
    [TestClass]
    public class UserApplicationTest
    {
        private static IConfiguration _configuration;
        private static IServiceScopeFactory _serviceScopeFactory;

        [ClassInitialize]
        public static void Initialize(TestContext _)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();
            var services = new ServiceCollection();
            services.AddInjection(_configuration);
            _serviceScopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();
        }

        [TestMethod]
        public void Authenticate_WhenDontSendParameters_ReturnValidationMessageErrors()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUserApplication>();

            #region Arrange: Donde se inicializan los objetos necesarios para la ejecución del código

            var username = string.Empty;
            var password = string.Empty;
            var expected = "Errores de Validación";

            #endregion

            #region Act: Donde se ejecuta el método que se va a probar y se obtiene el resultado

            var result = context.Authenticate(username, password);
            var actual = result.Message;

            #endregion

            #region Assert: Donde se comprueba que el resultado obtenido es el esperado

            Assert.AreEqual(expected, actual);

            #endregion
        }
    }
}
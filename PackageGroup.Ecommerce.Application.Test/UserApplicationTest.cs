using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using PackageGroup.Ecommerce.Application.Interface;

namespace PackageGroup.Ecommerce.Application.Test
{
    [TestClass]
    public class UserApplicationTest
    {
        private static WebApplicationFactory<Program> _factory = null;
        private static IServiceScopeFactory _serviceScopeFactory = null;

        [ClassInitialize]
        public static void Initialize(TestContext _)
        {
            _factory = new CustomWebApplicationFactory();
            _serviceScopeFactory = _factory.Services.GetRequiredService<IServiceScopeFactory>();
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
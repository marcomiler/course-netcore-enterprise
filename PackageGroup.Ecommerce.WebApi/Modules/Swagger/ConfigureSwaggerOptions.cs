using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PackageGroup.Ecommerce.WebApi.Modules.Swagger
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            this.provider = provider;
        }

        static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Version = description.ApiVersion.ToString(),
                Title = "PacaGroup Technology Services API Market",
                Description = "A simple example ASP.NET Core Web API",
                TermsOfService = new Uri("https://example.com/terms-of-service"),
                License = new OpenApiLicense
                {
                    Name = "Use under LICX",
                    Url = new Uri("https://example.com/license")
                },
                Contact = new OpenApiContact
                {
                    Name = "Miler R. Marco",
                    Email = "miler@gmail.com",
                    Url = new Uri("https://pacagroup.com")
                }
            };

            //SI TENEMOS VERSIONES DEPRECADAS:
            if (description.IsDeprecated)
            {
                info.Description += ". Esta versión de la API ha quedado obsoleta.";
            }

            return info;
        }

        public void Configure(SwaggerGenOptions options)
        {
            //Add a swagger document for each discovered API version
            //note: you might choose to skip or document deprecated API version differently
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }
    }
}

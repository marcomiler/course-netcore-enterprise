using Asp.Versioning;

namespace PackageGroup.Ecommerce.WebApi.Modules.Versioning
{
    public static class VersioningExtensions
    {
        public static IServiceCollection AddVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(o =>
            {
                o.DefaultApiVersion = new ApiVersion(1, 0);
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.ReportApiVersions = true;
                //QUERY STRING: api?api-version=v1.0
                //o.ApiVersionReader = new QueryStringApiVersionReader("api-version");

                //FOR HEADER
                //o.ApiVersionReader = new HeaderApiVersionReader("x-version");

                //FOR URL
                o.ApiVersionReader = new UrlSegmentApiVersionReader();
            })
            .AddApiExplorer(o =>
             {
                 o.GroupNameFormat = "'v'VVV";

                 //ESTA PROPIEDAD SOLO SI LA API_VERSIOV_READER ES UrlSegmentApiVersionReader
                 o.SubstituteApiVersionInUrl = true;
             });


            return services;
        }
    }
}

using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using PackageGroup.Ecommerce.WebApi.Modules.Authentication;
using PackageGroup.Ecommerce.WebApi.Modules.Feature;
using PackageGroup.Ecommerce.WebApi.Modules.HealthCheck;
using PackageGroup.Ecommerce.WebApi.Modules.Injection;
using PackageGroup.Ecommerce.WebApi.Modules.Mapper;
using PackageGroup.Ecommerce.WebApi.Modules.Swagger;
using PackageGroup.Ecommerce.WebApi.Modules.Validator;
using PackageGroup.Ecommerce.WebApi.Modules.Versioning;

var builder = WebApplication.CreateBuilder(args);
var myPolicy = "policyApiEcommerce";

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMapper();
builder.Services.AddFeature(builder.Configuration);
builder.Services.AddInjection(builder.Configuration);
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddVersioning();
builder.Services.AddSwagger();
builder.Services.AddValidator();
builder.Services.AddHealthCheck(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x =>
    {
        //SI NO EXISTE VERSIONAMIENTO, PUEDE SER UNA OPCIÓN
        //x.SwaggerEndpoint("/swagger/v1/swagger.json", "API ECOMMERCE V1");

        foreach (var description in app.DescribeApiVersions())
        {
            x.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
    });
}

app.UseCors(myPolicy);

//Definir la ruta por defecto al levantar el proyecto
//app.MapGet("/", () => Results.Redirect("swagger/index.html"));

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", () => Results.Redirect("swagger/index.html"));
    endpoints.MapControllers();
    endpoints.MapHealthChecksUI();

    //route for healthcheck ui: /healthchecks-ui
    endpoints.MapHealthChecks("/health", new HealthCheckOptions
    {
        Predicate = _ => true,
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });
});


app.Run();

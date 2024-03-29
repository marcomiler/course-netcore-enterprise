using Asp.Versioning.ApiExplorer;
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
using PackageGroup.Ecommerce.WebApi.Modules.Watch;
using WatchDog;

var builder = WebApplication.CreateBuilder(args);

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
builder.Services.AddWatchDog(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x =>
    {
        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        foreach (var description in provider.ApiVersionDescriptions)
        {
            x.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
    });
}

app.UseWatchDogExceptionLogger();
app.UseHttpsRedirection();
app.UseCors("policyApiEcommerce");

//Definir la ruta por defecto al levantar el proyecto
app.MapGet("/", () => Results.Redirect("swagger/index.html"));

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecksUI();
app.MapHealthChecks("/health", new HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseWatchDog(config =>
{
    config.WatchPageUsername = builder.Configuration["WatchDog:WatchPageUsername"];
    config.WatchPagePassword = builder.Configuration["WatchDog:WatchPagePassword"];
});
app.Run();

//Hacemos pública la clase Program para poder acceder a est desde TEST
public partial class Program { };
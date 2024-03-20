using PackageGroup.Ecommerce.WebApi.Modules.Authentication;
using PackageGroup.Ecommerce.WebApi.Modules.Feature;
using PackageGroup.Ecommerce.WebApi.Modules.Injection;
using PackageGroup.Ecommerce.WebApi.Modules.Mapper;
using PackageGroup.Ecommerce.WebApi.Modules.Swagger;
using PackageGroup.Ecommerce.WebApi.Modules.Validator;

var builder = WebApplication.CreateBuilder(args);
var myPolicy = "policyApiEcommerce";

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMapper();
builder.Services.AddFeature(builder.Configuration);
builder.Services.AddInjection(builder.Configuration);
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddSwagger();
builder.Services.AddValidator();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x =>
    {
        x.SwaggerEndpoint("/swagger/v1/swagger.json", "API ECOMMERCE V1");
    });
}

app.UseCors(myPolicy);
app.UseAuthentication();

//Definir la ruta por defecto al levantar el proyecto
app.MapGet("/", () => Results.Redirect("swagger/index.html"));
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();

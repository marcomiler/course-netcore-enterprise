using Microsoft.AspNetCore.Identity.Data;
using Microsoft.OpenApi.Models;
using PackageGroup.Ecommerce.Application.Interface;
using PackageGroup.Ecommerce.Application.Main;
using PackageGroup.Ecommerce.Domain.Core;
using PackageGroup.Ecommerce.Domain.Interface;
using PackageGroup.Ecommerce.Infrastructure.Data;
using PackageGroup.Ecommerce.Infrastructure.Interface;
using PackageGroup.Ecommerce.Infrastructure.Repository;
using PackageGroup.Ecommerce.Transversal.Common;
using PackageGroup.Ecommerce.Transversal.Mapper;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));

//builder.Services.AddMvc()
//    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
//    .AddJsonOptions(option => { option.JsonSerializerOptions. SerializerSettings.ContracResolver = new Newtonsoft.Json.Serialization.DefaultContratResolver(); })

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AllOrigins", b =>
    {
        b.AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin();
    });
});
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddSingleton<IConnectionFactory, ConnectionFactory>();
builder.Services.AddScoped<ICustomerApplication, CustomerApplication>();
builder.Services.AddScoped<ICustomersDomain, CustomersDomain>();
builder.Services.AddScoped<ICustomersRepository, CustomerRepository>();

//Definir documentación de Swagger | Reemplazar a conveniencia
//Tambien se realiza una configuración en las propiedades del proyecto actual
//exactamente en la opcion BUILD/output/XML Documentation File Path | aunq al parecer no afecta nada
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
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

    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    x.IncludeXmlComments(xmlPath);

});

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

//Definir la ruta por defecto al levantar el proyecto
app.MapGet("/", () => Results.Redirect("swagger/index.html"));
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();

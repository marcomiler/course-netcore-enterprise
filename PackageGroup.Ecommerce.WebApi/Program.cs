using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
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
using PackageGroup.Ecommerce.WebApi.Helpers;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var myPolicy = "policyApiEcommerce";

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));

//builder.Services.AddMvc()
//    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
//    .AddJsonOptions(option => { option.JsonSerializerOptions. SerializerSettings.ContracResolver = new Newtonsoft.Json.Serialization.DefaultContratResolver(); })

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(myPolicy, b =>
    {
        b.WithOrigins(builder.Configuration["Config:OriginCors"])
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var appSettingsSection = builder.Configuration.GetSection("Config");
builder.Services.Configure<AppSettings>(appSettingsSection);

var appSettings = appSettingsSection.Get<AppSettings>();

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddSingleton<IConnectionFactory, ConnectionFactory>();

builder.Services.AddScoped<IUserApplication, UserApplication>();
builder.Services.AddScoped<ICustomerApplication, CustomerApplication>();

builder.Services.AddScoped<IUserDomain, UserDomain>();
builder.Services.AddScoped<ICustomerDomain, CustomersDomain>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICustomersRepository, CustomerRepository>();

var key = Encoding.ASCII.GetBytes(appSettings.Secret);
var issuer = appSettings.Issuer;
var audience = appSettings.Audience;

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.Events = new JwtBearerEvents
    {
        OnTokenValidated = context =>
        {
            //Este valor se recupera del metodo BuildToken, donde creamos un Claim de tipo Name
            var userId = int.Parse(context.Principal.Identity.Name);
            return Task.CompletedTask;
        },

        OnAuthenticationFailed = context =>
        {
            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                context.Response.Headers.Add("Token-Expired", "true");

            return Task.CompletedTask;
        }
    };

    x.RequireHttpsMetadata = false;
    x.SaveToken = false;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidIssuer = issuer,
        ValidAudience = audience,
        ValidateAudience = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

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

    x.AddSecurityDefinition("Authorization", new OpenApiSecurityScheme
    {
        Description = "Authorization by API key",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Name = "Authorization",
        Scheme = "Bearer"
    });

    x.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
    //x.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
    //{
    //    { "Authorization", new string[0] }
    //});
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

app.UseCors(myPolicy);
app.UseAuthentication();

//Definir la ruta por defecto al levantar el proyecto
app.MapGet("/", () => Results.Redirect("swagger/index.html"));
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();

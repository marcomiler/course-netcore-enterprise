# Con esto solo se crea la imágen

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PackageGroup.Ecommerce.WebApi/PackageGroup.Ecommerce.WebApi.csproj", "PackageGroup.Ecommerce.WebApi/"]
COPY ["PackageGroup.Ecommerce.Application.DTO/PackageGroup.Ecommerce.Application.DTO.csproj", "PackageGroup.Ecommerce.Application.DTO/"]
COPY ["PackageGroup.Ecommerce.Application.Interface/PackageGroup.Ecommerce.Application.Interface.csproj", "PackageGroup.Ecommerce.Application.Interface/"]
COPY ["PackageGroup.Ecommerce.Transversal.Common/PackageGroup.Ecommerce.Transversal.Common.csproj", "PackageGroup.Ecommerce.Transversal.Common/"]
COPY ["PackageGroup.Ecommerce.Application.Main/PackageGroup.Ecommerce.Application.Main.csproj", "PackageGroup.Ecommerce.Application.Main/"]
COPY ["PackageGroup.Ecommerce.Domain.Entity/PackageGroup.Ecommerce.Domain.Entity.csproj", "PackageGroup.Ecommerce.Domain.Entity/"]
COPY ["PackageGroup.Ecommerce.Domain.Interface/PackageGroup.Ecommerce.Domain.Interface.csproj", "PackageGroup.Ecommerce.Domain.Interface/"]
COPY ["PackageGroup.Ecommerce.Domain.Core/PackageGroup.Ecommerce.Domain.Core.csproj", "PackageGroup.Ecommerce.Domain.Core/"]
COPY ["PackageGroup.Ecommerce.Infrastructure.Interface/PackageGroup.Ecommerce.Infrastructure.Interface.csproj", "PackageGroup.Ecommerce.Infrastructure.Interface/"]
COPY ["PackageGroup.Ecommerce.Infrastructure.Data/PackageGroup.Ecommerce.Infrastructure.Data.csproj", "PackageGroup.Ecommerce.Infrastructure.Data/"]
COPY ["PackageGroup.Ecommerce.Infrastructure.Repository/PackageGroup.Ecommerce.Infrastructure.Repository.csproj", "PackageGroup.Ecommerce.Infrastructure.Repository/"]
COPY ["PackageGroup.Ecommerce.Transversal.Logging/PackageGroup.Ecommerce.Transversal.Logging.csproj", "PackageGroup.Ecommerce.Transversal.Logging/"]
COPY ["PackageGroup.Ecommerce.Transversal.Mapper/PackageGroup.Ecommerce.Transversal.Mapper.csproj", "PackageGroup.Ecommerce.Transversal.Mapper/"]
RUN dotnet restore "./PackageGroup.Ecommerce.WebApi/./PackageGroup.Ecommerce.WebApi.csproj"
COPY . .
WORKDIR "/src/PackageGroup.Ecommerce.WebApi"
RUN dotnet build "./PackageGroup.Ecommerce.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PackageGroup.Ecommerce.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PackageGroup.Ecommerce.WebApi.dll"]
FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /src
COPY ["src/BlueXT.MobileMonitoring.HttpApi.Host/BlueXT.MobileMonitoring.HttpApi.Host.csproj", "src/BlueXT.MobileMonitoring.HttpApi.Host/"]
COPY ["src/BlueXT.MobileMonitoring.Application/BlueXT.MobileMonitoring.Application.csproj", "src/BlueXT.MobileMonitoring.Application/"]
COPY ["src/BlueXT.MobileMonitoring.Application.Mapster/BlueXT.MobileMonitoring.Application.Mapster.csproj", "src/BlueXT.MobileMonitoring.Application.Mapster/"]
COPY ["src/BlueXT.MobileMonitoring.Domain/BlueXT.MobileMonitoring.Domain.csproj", "src/BlueXT.MobileMonitoring.Domain/"]
COPY ["src/BlueXT.MobileMonitoring.Domain.Shared/BlueXT.MobileMonitoring.Domain.Shared.csproj", "src/BlueXT.MobileMonitoring.Domain.Shared/"]
COPY ["src/BlueXT.MobileMonitoring.Application.Contracts/BlueXT.MobileMonitoring.Application.Contracts.csproj", "src/BlueXT.MobileMonitoring.Application.Contracts/"]
COPY ["src/BlueXT.MobileMonitoring.Dapper/BlueXT.MobileMonitoring.Dapper.csproj", "src/BlueXT.MobileMonitoring.Dapper/"]
COPY ["src/BlueXT.MobileMonitoring.EntityFrameworkCore/BlueXT.MobileMonitoring.EntityFrameworkCore.csproj", "src/BlueXT.MobileMonitoring.EntityFrameworkCore/"]
COPY ["src/BlueXT.MobileMonitoring.HttpApi/BlueXT.MobileMonitoring.HttpApi.csproj", "src/BlueXT.MobileMonitoring.HttpApi/"]
RUN dotnet restore "src/BlueXT.MobileMonitoring.HttpApi.Host/BlueXT.MobileMonitoring.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/src/BlueXT.MobileMonitoring.HttpApi.Host"
RUN dotnet build "BlueXT.MobileMonitoring.HttpApi.Host.csproj" -c Release -o /app/build --no-restore

FROM build AS publish
RUN dotnet publish "BlueXT.MobileMonitoring.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlueXT.MobileMonitoring.HttpApi.Host.dll"]

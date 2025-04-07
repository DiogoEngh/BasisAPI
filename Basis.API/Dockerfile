FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Basis.API/Basis.API.csproj", "Basis.API/"]
COPY ["Basis.Application/Basis.Application.csproj", "Basis.Application/"]
COPY ["Basis.Domain/Basis.Domain.csproj", "Basis.Domain/"]
COPY ["Basis.Infrastructure/Basis.Infrastructure.csproj", "Basis.Infrastructure/"]
RUN dotnet restore "./Basis.API/Basis.API.csproj"
COPY . .
WORKDIR "/src/Basis.API"
RUN dotnet build "./Basis.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Basis.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Basis.API.dll"]
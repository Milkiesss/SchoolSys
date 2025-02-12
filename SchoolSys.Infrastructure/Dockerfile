FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SchoolSys.Infrastructure/SchoolSys.Infrastructure.csproj", "SchoolSys.Infrastructure/"]
RUN dotnet restore "SchoolSys.Infrastructure/SchoolSys.Infrastructure.csproj"
COPY . .
WORKDIR "/src/SchoolSys.Infrastructure"
RUN dotnet build "SchoolSys.Infrastructure.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SchoolSys.Infrastructure.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SchoolSys.Infrastructure.dll"]

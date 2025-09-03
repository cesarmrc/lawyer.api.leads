FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
ENV DOTNET_ENVIRONMENT=Docker
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["lawyer.api.leads.webapi/lawyer.api.leads.webapi.csproj", "lawyer.api.leads.webapi/"]
COPY ["lawyer.api.leads.application/lawyer.api.leads.application.csproj", "lawyer.api.leads.application/"]
COPY ["lawyer.api.leads.domain/lawyer.api.leads.domain.csproj", "lawyer.api.leads.domain/"]
COPY ["lawyer.api.leads.datastore.mssql/lawyer.api.leads.datastore.mssql.csproj", "lawyer.api.leads.datastore.mssql/"]
RUN dotnet restore "lawyer.api.leads.webapi/lawyer.api.leads.webapi.csproj"
COPY . .
WORKDIR "/src/lawyer.api.leads.webapi"
RUN dotnet build "./lawyer.api.leads.webapi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./lawyer.api.leads.webapi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "lawyer.api.leads.webapi.dll"]

using lawyer.api.leads.application.Contracts.Interfaces.Persistence.Example;
using lawyer.api.leads.application.Contracts.Interfaces.Persistence.City;
using lawyer.api.leads.application.Contracts.Interfaces.Persistence.Country;
using lawyer.api.leads.datastore.mssql.DatabaseContext;
using lawyer.api.leads.datastore.mssql.Model.MappingProfile;
using lawyer.api.leads.datastore.mssql.Repositories.Example;
using lawyer.api.leads.datastore.mssql.Repositories.City;
using lawyer.api.leads.datastore.mssql.Repositories.Country;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace lawyer.api.leads.datastore.mssql;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<LawyersContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("LawyersConnectionString")));
        services.AddAutoMapper(typeof(ApplicationMappingProfile).Assembly);
        services.AddScoped<IExampleCommandRepository, ExampleCommandRepository>();
        services.AddScoped<IExampleQueryRepository, ExampleQueryRepository>();
        services.AddScoped<ICityCommandRepository, CityCommandRepository>();
        services.AddScoped<ICityQueryRepository, CityQueryRepository>();
        services.AddScoped<ICountryCommandRepository, CountryCommandRepository>();
        services.AddScoped<ICountryQueryRepository, CountryQueryRepository>();

        return services;
    }
}
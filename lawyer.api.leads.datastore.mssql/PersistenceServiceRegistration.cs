using lawyer.api.leads.application.Contracts.Interfaces.Persistence.Example;
using lawyer.api.leads.application.Contracts.Interfaces.Persistence.LeadState;
using lawyer.api.leads.application.Contracts.Interfaces.Persistence.Lead;
using lawyer.api.leads.application.Contracts.Interfaces.Persistence.LeadMessage;
using lawyer.api.leads.datastore.mssql.DatabaseContext;
using lawyer.api.leads.datastore.mssql.Model.MappingProfile;
using lawyer.api.leads.datastore.mssql.Repositories.Example;
using lawyer.api.leads.datastore.mssql.Repositories.LeadState;
using lawyer.api.leads.datastore.mssql.Repositories.Lead;
using lawyer.api.leads.datastore.mssql.Repositories.LeadMessage;
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
        services.AddScoped<ILeadStateCommandRepository, LeadStateCommandRepository>();
        services.AddScoped<ILeadStateQueryRepository, LeadStateQueryRepository>();
        services.AddScoped<ILeadCommandRepository, LeadCommandRepository>();
        services.AddScoped<ILeadQueryRepository, LeadQueryRepository>();
        services.AddScoped<ILeadMessageCommandRepository, LeadMessageCommandRepository>();
        services.AddScoped<ILeadMessageQueryRepository, LeadMessageQueryRepository>();

        return services;
    }
}
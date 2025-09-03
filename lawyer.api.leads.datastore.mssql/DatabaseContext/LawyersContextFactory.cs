using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace lawyer.api.leads.datastore.mssql.DatabaseContext;

public class LawyersContextFactory : IDesignTimeDbContextFactory<LawyersContext>
{
    public LawyersContext CreateDbContext(string[] args)
    {
        // Configuración para cargar el appsettings.json en tiempo de diseño
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        // Construir opciones para el DbContext
        var optionsBuilder = new DbContextOptionsBuilder<LawyersContext>();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("LawyersConnectionString"));

        return new LawyersContext(optionsBuilder.Options);
    }
}
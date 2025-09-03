using lawyer.api.leads.datastore.mssql.Model;
using lawyer.api.leads.datastore.mssql.Model.Common;
using Microsoft.EntityFrameworkCore;

namespace lawyer.api.leads.datastore.mssql.DatabaseContext;

public class LawyersContext : DbContext
{
    public LawyersContext(DbContextOptions<LawyersContext> options) : base(options)
    {
    }

    public DbSet<ExampleEntity> Examples { get; set; }
    public DbSet<LeadStateEntity> LeadStates { get; set; }
    public DbSet<LeadEntity> Leads { get; set; }
    public DbSet<LeadMessageEntity> LeadMessages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LawyersContext).Assembly);
        
        modelBuilder.Entity<LeadEntity>()
            .HasOne(c => c.LeadState)
            .WithMany(leadState => leadState.Leads)
            .HasForeignKey(c => c.IdLeadState);
        
        modelBuilder.Entity<LeadMessageEntity>()
            .HasOne(c => c.Lead)
            .WithMany(c => c.LeadMessages)
            .HasForeignKey(c => c.IdLead);

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<EFEntity>()
                     .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
        {
            entry.Entity.DateModified = DateTime.Now;
            if (entry.State == EntityState.Added) entry.Entity.DateCreated = DateTime.Now;
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
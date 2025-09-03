using System.Text.Json;
using AutoMapper;
using lawyer.api.leads.application.Contracts.Interfaces.Persistence.Common;
using lawyer.api.leads.datastore.mssql.DatabaseContext;
using lawyer.api.leads.datastore.mssql.Model.Common;
using lawyer.api.leads.domain.Common;

namespace lawyer.api.leads.datastore.mssql.Repositories.Common;

public class CommandRepository<T, TEntity> : ICommandRepository<T>
    where T : BaseEntity
    where TEntity : EFEntity
{
    private readonly LawyersContext _dbContext;
    private readonly IMapper _mapper;

    public CommandRepository(LawyersContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task CreateAsync(T entity)
    {
        var dbEntity = _mapper.Map<TEntity>(entity);

        Console.WriteLine($"Data before store: {JsonSerializer.Serialize(dbEntity)}");

        _dbContext.Add((object)dbEntity);
        await _dbContext.SaveChangesAsync();

        _mapper.Map(dbEntity, entity);
    }

    public async Task UpdateAsync(T entity)
    {
        var dbEntity = _mapper.Map<TEntity>(entity);
        _dbContext.Update(dbEntity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        var dbEntity = _mapper.Map<TEntity>(entity);
        _dbContext.Remove(dbEntity);
        await _dbContext.SaveChangesAsync();
    }
}
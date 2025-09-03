using AutoMapper;
using lawyer.api.leads.application.Contracts.Interfaces.Persistence.Common;
using lawyer.api.leads.datastore.mssql.DatabaseContext;
using lawyer.api.leads.datastore.mssql.Model.Common;
using lawyer.api.leads.domain.Common;
using Microsoft.EntityFrameworkCore;

namespace lawyer.api.leads.datastore.mssql.Repositories.Common;

public class QueryRepository<T, TEntity> : IQueryRepository<T>
    where T : BaseEntity
    where TEntity : EFEntity
{
    private readonly LawyersContext _dbContext;
    private readonly IMapper _mapper;

    public QueryRepository(LawyersContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<T> GetByIdAsync(Guid id, params string[] includes)
    {
        var query = _dbContext.Set<TEntity>().AsNoTracking();
        query = includes.Aggregate(query, (current, include) => current.Include(include));
        var entity = await query.FirstOrDefaultAsync(e => e.Id == id);
        return entity == null ? null : _mapper.Map<T>(entity);
    }

    public async Task<List<T>> GetAllAsync(params string[] includes)
    {
        var query = _dbContext.Set<TEntity>().AsNoTracking();
        foreach (var include in includes) query = query.Include(include);
        var entities = await query.ToListAsync();
        return _mapper.Map<List<T>>(entities);
    }
}
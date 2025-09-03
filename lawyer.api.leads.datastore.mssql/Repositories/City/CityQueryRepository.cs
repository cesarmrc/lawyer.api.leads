using AutoMapper;
using lawyer.api.leads.application.Contracts.Interfaces.Persistence.City;
using lawyer.api.leads.datastore.mssql.DatabaseContext;
using lawyer.api.leads.datastore.mssql.Model;
using lawyer.api.leads.datastore.mssql.Repositories.Common;

namespace lawyer.api.leads.datastore.mssql.Repositories.City;

public class CityQueryRepository : QueryRepository<domain.City, CityEntity>, ICityQueryRepository
{
    private readonly IMapper _mapper;

    public CityQueryRepository(LawyersContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
        _mapper = mapper;
    }
}

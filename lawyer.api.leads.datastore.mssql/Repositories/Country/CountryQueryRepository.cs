using AutoMapper;
using lawyer.api.leads.application.Contracts.Interfaces.Persistence.Country;
using lawyer.api.leads.datastore.mssql.DatabaseContext;
using lawyer.api.leads.datastore.mssql.Model;
using lawyer.api.leads.datastore.mssql.Repositories.Common;

namespace lawyer.api.leads.datastore.mssql.Repositories.Country;

public class CountryQueryRepository : QueryRepository<domain.Country, CountryEntity>, ICountryQueryRepository
{
    private readonly IMapper _mapper;

    public CountryQueryRepository(LawyersContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
        _mapper = mapper;
    }
}

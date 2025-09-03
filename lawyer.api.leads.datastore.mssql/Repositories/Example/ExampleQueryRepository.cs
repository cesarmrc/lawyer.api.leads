using AutoMapper;
using lawyer.api.leads.application.Contracts.Interfaces.Persistence.Example;
using lawyer.api.leads.datastore.mssql.DatabaseContext;
using lawyer.api.leads.datastore.mssql.Model;
using lawyer.api.leads.datastore.mssql.Repositories.Common;

namespace lawyer.api.leads.datastore.mssql.Repositories.Example;

public class ExampleQueryRepository : QueryRepository<domain.Example, ExampleEntity>, IExampleQueryRepository
{
    private readonly IMapper _mapper;

    public ExampleQueryRepository(LawyersContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
        _mapper = mapper;
    }
}

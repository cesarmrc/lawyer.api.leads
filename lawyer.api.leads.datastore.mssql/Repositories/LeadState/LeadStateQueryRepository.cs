using AutoMapper;
using lawyer.api.leads.application.Contracts.Interfaces.Persistence.LeadState;
using lawyer.api.leads.datastore.mssql.DatabaseContext;
using lawyer.api.leads.datastore.mssql.Model;
using lawyer.api.leads.datastore.mssql.Repositories.Common;

namespace lawyer.api.leads.datastore.mssql.Repositories.LeadState;

public class LeadStateQueryRepository : QueryRepository<domain.LeadState, LeadStateEntity>, ILeadStateQueryRepository
{
    private readonly IMapper _mapper;

    public LeadStateQueryRepository(LawyersContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
        _mapper = mapper;
    }
}


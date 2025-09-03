using AutoMapper;
using lawyer.api.leads.application.Contracts.Interfaces.Persistence.LeadMessage;
using lawyer.api.leads.datastore.mssql.DatabaseContext;
using lawyer.api.leads.datastore.mssql.Model;
using lawyer.api.leads.datastore.mssql.Repositories.Common;

namespace lawyer.api.leads.datastore.mssql.Repositories.LeadMessage;

public class LeadMessageQueryRepository : QueryRepository<domain.LeadMessage, LeadMessageEntity>, ILeadMessageQueryRepository
{
    private readonly IMapper _mapper;

    public LeadMessageQueryRepository(LawyersContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
        _mapper = mapper;
    }
}


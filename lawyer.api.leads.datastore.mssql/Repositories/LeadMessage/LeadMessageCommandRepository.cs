using AutoMapper;
using lawyer.api.leads.application.Contracts.Interfaces.Persistence.LeadMessage;
using lawyer.api.leads.datastore.mssql.DatabaseContext;
using lawyer.api.leads.datastore.mssql.Model;
using lawyer.api.leads.datastore.mssql.Repositories.Common;

namespace lawyer.api.leads.datastore.mssql.Repositories.LeadMessage;

public class LeadMessageCommandRepository : CommandRepository<domain.LeadMessage, LeadMessageEntity>, ILeadMessageCommandRepository
{
    private readonly IMapper _mapper;

    public LeadMessageCommandRepository(LawyersContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
        _mapper = mapper;
    }
}


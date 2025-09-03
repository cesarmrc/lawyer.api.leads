using AutoMapper;
using lawyer.api.leads.application.Contracts.Interfaces.Persistence.Lead;
using lawyer.api.leads.datastore.mssql.DatabaseContext;
using lawyer.api.leads.datastore.mssql.Model;
using lawyer.api.leads.datastore.mssql.Repositories.Common;

namespace lawyer.api.leads.datastore.mssql.Repositories.Lead;

public class LeadQueryRepository : QueryRepository<domain.Lead, LeadEntity>, ILeadQueryRepository
{
    private readonly IMapper _mapper;

    public LeadQueryRepository(LawyersContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
        _mapper = mapper;
    }
}

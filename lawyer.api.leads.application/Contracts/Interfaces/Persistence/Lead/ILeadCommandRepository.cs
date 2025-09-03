using lawyer.api.leads.application.Contracts.Interfaces.Persistence.Common;

namespace lawyer.api.leads.application.Contracts.Interfaces.Persistence.Lead;

public interface ILeadCommandRepository : ICommandRepository<domain.Lead>
{
}

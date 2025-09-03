using lawyer.api.leads.application.Contracts.Interfaces.Persistence.Common;

namespace lawyer.api.leads.application.Contracts.Interfaces.Persistence.Example;

public interface IExampleCommandRepository : ICommandRepository<domain.Example>
{
}

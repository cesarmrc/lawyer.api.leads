using lawyer.api.leads.application.Contracts.Interfaces.Persistence.LeadState;
using MediatR;

namespace lawyer.api.leads.application.UseCases.LeadState.Update;

public class UpdateLeadStateCommandHandler : IRequestHandler<UpdateLeadStateCommand, Guid>
{
    private readonly ILeadStateCommandRepository _command;
    private readonly ILeadStateQueryRepository _query;

    public UpdateLeadStateCommandHandler(ILeadStateCommandRepository command, ILeadStateQueryRepository query)
    {
        _command = command;
        _query = query;
    }

    public async Task<Guid> Handle(UpdateLeadStateCommand request, CancellationToken cancellationToken)
    {
        var entity = await _query.GetByIdAsync(request.Id);
        if (entity == null) throw new KeyNotFoundException($"The lead state with ID {request.Id} does not exist.");

        entity.State = request.State;
        entity.DateModified = DateTime.UtcNow;

        await _command.UpdateAsync(entity);
        return entity.Id;
    }
}


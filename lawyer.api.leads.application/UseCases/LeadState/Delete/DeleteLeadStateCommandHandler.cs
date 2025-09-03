using lawyer.api.leads.application.Contracts.Interfaces.Persistence.LeadState;
using MediatR;

namespace lawyer.api.leads.application.UseCases.LeadState.Delete;

public class DeleteLeadStateCommandHandler : IRequestHandler<DeleteLeadStateCommand, Unit>
{
    private readonly ILeadStateCommandRepository _command;
    private readonly ILeadStateQueryRepository _query;

    public DeleteLeadStateCommandHandler(ILeadStateCommandRepository command, ILeadStateQueryRepository query)
    {
        _command = command;
        _query = query;
    }

    public async Task<Unit> Handle(DeleteLeadStateCommand request, CancellationToken cancellationToken)
    {
        var entity = await _query.GetByIdAsync(request.Id);
        await _command.DeleteAsync(entity);
        return Unit.Value;
    }
}


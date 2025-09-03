using lawyer.api.leads.application.Contracts.Interfaces.Persistence.LeadMessage;
using MediatR;

namespace lawyer.api.leads.application.UseCases.LeadMessage.Delete;

public class DeleteLeadMessageCommandHandler : IRequestHandler<DeleteLeadMessageCommand, Unit>
{
    private readonly ILeadMessageCommandRepository _command;
    private readonly ILeadMessageQueryRepository _query;

    public DeleteLeadMessageCommandHandler(ILeadMessageCommandRepository command, ILeadMessageQueryRepository query)
    {
        _command = command;
        _query = query;
    }

    public async Task<Unit> Handle(DeleteLeadMessageCommand request, CancellationToken cancellationToken)
    {
        var entity = await _query.GetByIdAsync(request.Id);
        await _command.DeleteAsync(entity);
        return Unit.Value;
    }
}


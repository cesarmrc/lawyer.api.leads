using lawyer.api.leads.application.Contracts.Interfaces.Persistence.Lead;
using MediatR;

namespace lawyer.api.leads.application.UseCases.Lead.Delete;

public class DeleteLeadCommandHandler : IRequestHandler<DeleteLeadCommand, Unit>
{
    private readonly ILeadCommandRepository _command;
    private readonly ILeadQueryRepository _query;

    public DeleteLeadCommandHandler(ILeadCommandRepository command, ILeadQueryRepository query)
    {
        _command = command;
        _query = query;
    }

    public async Task<Unit> Handle(DeleteLeadCommand request, CancellationToken cancellationToken)
    {
        var entity = await _query.GetByIdAsync(request.Id);
        await _command.DeleteAsync(entity);
        return Unit.Value;
    }
}

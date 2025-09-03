using lawyer.api.leads.application.Contracts.Interfaces.Persistence.Example;
using MediatR;

namespace lawyer.api.leads.application.UseCases.Example.Delete;

public class DeleteExampleCommandHandler : IRequestHandler<DeleteExampleCommand, Unit>
{
    private readonly IExampleCommandRepository _command;
    private readonly IExampleQueryRepository _query;

    public DeleteExampleCommandHandler(IExampleCommandRepository command, IExampleQueryRepository query)
    {
        _command = command;
        _query = query;
    }

    public async Task<Unit> Handle(DeleteExampleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _query.GetByIdAsync(request.Id);
        await _command.DeleteAsync(entity);
        return Unit.Value;
    }
}

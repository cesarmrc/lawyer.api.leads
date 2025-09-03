using lawyer.api.leads.application.Contracts.Interfaces.Persistence.City;
using MediatR;

namespace lawyer.api.leads.application.UseCases.City.Delete;

public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, Unit>
{
    private readonly ICityCommandRepository _command;
    private readonly ICityQueryRepository _query;

    public DeleteCityCommandHandler(ICityCommandRepository command, ICityQueryRepository query)
    {
        _command = command;
        _query = query;
    }

    public async Task<Unit> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
    {
        var entity = await _query.GetByIdAsync(request.Id);
        await _command.DeleteAsync(entity);
        return Unit.Value;
    }
}

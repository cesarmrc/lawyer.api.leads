using lawyer.api.leads.application.Contracts.Interfaces.Persistence.Example;
using MediatR;

namespace lawyer.api.leads.application.UseCases.Example.Update;

public class UpdateExampleCommandHandler : IRequestHandler<UpdateExampleCommand, Guid>
{
    private readonly IExampleCommandRepository _command;
    private readonly IExampleQueryRepository _query;

    public UpdateExampleCommandHandler(
        IExampleCommandRepository command,
        IExampleQueryRepository query)
    {
        _command = command;
        _query = query;
    }

    public async Task<Guid> Handle(UpdateExampleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _query.GetByIdAsync(request.Id);
        if (entity == null) throw new KeyNotFoundException($"The example with ID {request.Id} does not exist.");

        entity.PropertyOne = request.PropertyOne;
        entity.PropertyTwo = request.PropertyTwo;
        entity.DateModified = DateTime.UtcNow;

        await _command.UpdateAsync(entity);
        return entity.Id;
    }
}

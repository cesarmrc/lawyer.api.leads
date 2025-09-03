using lawyer.api.leads.application.Contracts.Interfaces.Persistence.Country;
using MediatR;

namespace lawyer.api.leads.application.UseCases.Country.Update;

public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, Guid>
{
    private readonly ICountryCommandRepository _command;
    private readonly ICountryQueryRepository _query;

    public UpdateCountryCommandHandler(
        ICountryCommandRepository command,
        ICountryQueryRepository query)
    {
        _command = command;
        _query = query;
    }

    public async Task<Guid> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _query.GetByIdAsync(request.Id);
        if (entity == null) throw new KeyNotFoundException($"The country with ID {request.Id} does not exist.");

        entity.Name = request.Name;
        entity.DateModified = DateTime.UtcNow;

        await _command.UpdateAsync(entity);
        return entity.Id;
    }
}

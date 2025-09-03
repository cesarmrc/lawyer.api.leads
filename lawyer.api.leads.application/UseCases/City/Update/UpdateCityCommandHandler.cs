using lawyer.api.leads.application.Contracts.Interfaces.Persistence.City;
using MediatR;

namespace lawyer.api.leads.application.UseCases.City.Update;

public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, Guid>
{
    private readonly ICityCommandRepository _command;
    private readonly ICityQueryRepository _query;

    public UpdateCityCommandHandler(
        ICityCommandRepository command,
        ICityQueryRepository query)
    {
        _command = command;
        _query = query;
    }

    public async Task<Guid> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
    {
        var entity = await _query.GetByIdAsync(request.Id);
        if (entity == null) throw new KeyNotFoundException($"The city with ID {request.Id} does not exist.");

        entity.IdCountry = request.IdCountry;
        entity.Name = request.Name;
        entity.DateModified = DateTime.UtcNow;

        await _command.UpdateAsync(entity);
        return entity.Id;
    }
}

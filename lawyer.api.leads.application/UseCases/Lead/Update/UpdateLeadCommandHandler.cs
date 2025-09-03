using lawyer.api.leads.application.Contracts.Interfaces.Persistence.Lead;
using MediatR;

namespace lawyer.api.leads.application.UseCases.Lead.Update;

public class UpdateLeadCommandHandler : IRequestHandler<UpdateLeadCommand, Guid>
{
    private readonly ILeadCommandRepository _command;
    private readonly ILeadQueryRepository _query;

    public UpdateLeadCommandHandler(
        ILeadCommandRepository command,
        ILeadQueryRepository query)
    {
        _command = command;
        _query = query;
    }

    public async Task<Guid> Handle(UpdateLeadCommand request, CancellationToken cancellationToken)
    {
        var entity = await _query.GetByIdAsync(request.Id);
        if (entity == null) throw new KeyNotFoundException($"The lead with ID {request.Id} does not exist.");

        entity.IdLeadState = request.IdLeadState;
        entity.IdUser = request.IdUser;
        entity.IdLawFirm = request.IdLawFirm;
        entity.Brief = request.Brief;
        entity.DateModified = DateTime.UtcNow;

        await _command.UpdateAsync(entity);
        return entity.Id;
    }
}

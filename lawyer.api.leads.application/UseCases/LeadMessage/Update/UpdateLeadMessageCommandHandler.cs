using lawyer.api.leads.application.Contracts.Interfaces.Persistence.LeadMessage;
using MediatR;

namespace lawyer.api.leads.application.UseCases.LeadMessage.Update;

public class UpdateLeadMessageCommandHandler : IRequestHandler<UpdateLeadMessageCommand, Guid>
{
    private readonly ILeadMessageCommandRepository _command;
    private readonly ILeadMessageQueryRepository _query;

    public UpdateLeadMessageCommandHandler(
        ILeadMessageCommandRepository command,
        ILeadMessageQueryRepository query)
    {
        _command = command;
        _query = query;
    }

    public async Task<Guid> Handle(UpdateLeadMessageCommand request, CancellationToken cancellationToken)
    {
        var entity = await _query.GetByIdAsync(request.Id);
        if (entity == null) throw new KeyNotFoundException($"The LeadMessage with ID {request.Id} does not exist.");

        entity.IdLead = request.IdLead;
        entity.IdUser = request.IdUser;
        entity.UserType = request.UserType;
        entity.Text = request.Text;
        entity.DateModified = DateTime.UtcNow;

        await _command.UpdateAsync(entity);
        return entity.Id;
    }
}


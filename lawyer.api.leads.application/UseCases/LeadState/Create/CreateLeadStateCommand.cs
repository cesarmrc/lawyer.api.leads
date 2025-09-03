using MediatR;

namespace lawyer.api.leads.application.UseCases.LeadState.Create;

public class CreateLeadStateCommand : IRequest<Guid>
{
    public Guid State { get; set; }
}


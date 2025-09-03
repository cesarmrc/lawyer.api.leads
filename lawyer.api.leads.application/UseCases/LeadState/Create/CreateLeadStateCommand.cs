using MediatR;

namespace lawyer.api.leads.application.UseCases.LeadState.Create;

public class CreateLeadStateCommand : IRequest<Guid>
{
    public string State { get; set; } = string.Empty;
}


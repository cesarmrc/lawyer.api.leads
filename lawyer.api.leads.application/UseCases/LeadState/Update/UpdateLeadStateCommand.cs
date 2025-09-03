using MediatR;

namespace lawyer.api.leads.application.UseCases.LeadState.Update;

public class UpdateLeadStateCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string State { get; set; } = string.Empty;
}


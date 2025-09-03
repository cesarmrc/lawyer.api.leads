using MediatR;

namespace lawyer.api.leads.application.UseCases.LeadState.Delete;

public class DeleteLeadStateCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}


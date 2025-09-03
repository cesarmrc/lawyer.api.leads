using MediatR;

namespace lawyer.api.leads.application.UseCases.LeadMessage.Delete;

public class DeleteLeadMessageCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}


using MediatR;

namespace lawyer.api.leads.application.UseCases.Lead.Delete;

public class DeleteLeadCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}

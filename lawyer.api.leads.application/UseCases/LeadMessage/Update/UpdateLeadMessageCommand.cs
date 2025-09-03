using MediatR;

namespace lawyer.api.leads.application.UseCases.LeadMessage.Update;

public class UpdateLeadMessageCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public Guid IdLead { get; set; }
    public Guid IdUser { get; set; }
    public int UserType { get; set; }
    public string Text { get; set; } = string.Empty;
}


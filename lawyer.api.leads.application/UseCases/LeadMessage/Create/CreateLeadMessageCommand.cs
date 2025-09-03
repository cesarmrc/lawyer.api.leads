using MediatR;

namespace lawyer.api.leads.application.UseCases.LeadMessage.Create;

public class CreateLeadMessageCommand : IRequest<Guid>
{
    public Guid IdLead { get; set; }
    public Guid IdUser { get; set; }
    public int UserType { get; set; }
    public string Text { get; set; } = string.Empty;
}


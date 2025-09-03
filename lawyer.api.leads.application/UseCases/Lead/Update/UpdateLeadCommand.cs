using MediatR;

namespace lawyer.api.leads.application.UseCases.Lead.Update;

public class UpdateLeadCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public Guid IdLeadState { get; set; }
    public Guid IdUser { get; set; }
    public Guid IdLawFirm { get; set; }
    public string Brief { get; set; } = string.Empty;
}

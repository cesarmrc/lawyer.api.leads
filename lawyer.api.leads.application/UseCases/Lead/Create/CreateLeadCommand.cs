using MediatR;

namespace lawyer.api.leads.application.UseCases.Lead.Create;

public class CreateLeadCommand : IRequest<Guid>
{
    public Guid IdLeadState { get; set; }
    public Guid IdUser { get; set; }
    public Guid IdLawFirm { get; set; }
    public string Brief { get; set; } = string.Empty;
}

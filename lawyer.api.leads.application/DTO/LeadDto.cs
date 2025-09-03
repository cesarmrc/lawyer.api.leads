namespace lawyer.api.leads.application.DTO;

public class LeadDto
{
    public Guid Id { get; set; }
    public Guid IdLeadState { get; set; }
    public Guid IdUser { get; set; }
    public Guid IdLawFirm { get; set; }
    public string Brief { get; set; } = string.Empty;
}

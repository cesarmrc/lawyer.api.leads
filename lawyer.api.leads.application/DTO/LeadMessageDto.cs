namespace lawyer.api.leads.application.DTO;

public class LeadMessageDto
{
    public Guid Id { get; set; }
    public Guid IdLead { get; set; }
    public Guid IdUser { get; set; }
    public int UserType { get; set; }
    public string Text { get; set; } = string.Empty;
}


using lawyer.api.leads.domain.Common;

namespace lawyer.api.leads.domain;

public class LeadMessage : BaseEntity
{
    public Guid IdLead { get; set; }
    public Guid IdUser { get; set; }
    public int UserType { get; set; }
    public string Text { get; set; } = string.Empty;
}


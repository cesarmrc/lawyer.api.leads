using lawyer.api.leads.domain.Common;

namespace lawyer.api.leads.domain;

public class LeadState : BaseEntity
{
    public string State { get; set; } = string.Empty;
}


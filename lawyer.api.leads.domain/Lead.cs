using lawyer.api.leads.domain.Common;

namespace lawyer.api.leads.domain;

public class Lead : BaseEntity
{
    public Guid IdLeadState { get; set; }
    public Guid IdUser { get; set; }
    public Guid IdLawFirm { get; set; }
    public string Brief { get; set; } = string.Empty;
}

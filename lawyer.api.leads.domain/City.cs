using lawyer.api.leads.domain.Common;

namespace lawyer.api.leads.domain;

public class City : BaseEntity
{
    public Guid IdCountry { get; set; }
    public string Name { get; set; } = string.Empty;
}

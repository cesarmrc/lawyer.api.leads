using System.Collections.Generic;
using lawyer.api.leads.domain.Common;

namespace lawyer.api.leads.domain;

public class Country : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public List<City> Cities { get; set; } = new();
}

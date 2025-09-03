using System.ComponentModel.DataAnnotations.Schema;
using lawyer.api.leads.datastore.mssql.Model.Common;

namespace lawyer.api.leads.datastore.mssql.Model;

[Table("LeadStates", Schema = "leads")]
public class LeadStateEntity : EFEntity
{
    public Guid State { get; set; }
}


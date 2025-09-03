using System.ComponentModel.DataAnnotations.Schema;
using lawyer.api.leads.datastore.mssql.Model.Common;

namespace lawyer.api.leads.datastore.mssql.Model;

[Table("Leads", Schema = "leads")]
public class LeadEntity : EFEntity
{
    public Guid IdLeadState { get; set; }
    public Guid IdUser { get; set; }
    public Guid IdLawFirm { get; set; }
    public string Brief { get; set; }

    [ForeignKey(nameof(IdLeadState))]
    public LeadStateEntity LeadState { get; set; }
    public ICollection<LeadMessageEntity> LeadMessages { get; set; }
}

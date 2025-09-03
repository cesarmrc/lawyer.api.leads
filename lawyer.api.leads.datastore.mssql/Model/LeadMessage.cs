using System.ComponentModel.DataAnnotations.Schema;
using lawyer.api.leads.datastore.mssql.Model.Common;

namespace lawyer.api.leads.datastore.mssql.Model;

[Table("LeadMessages", Schema = "leads")]
public class LeadMessageEntity : EFEntity
{
    public Guid IdLead { get; set; }
    public Guid IdUser { get; set; }
    public int UserType { get; set; }
    public string Text { get; set; }

    [ForeignKey(nameof(IdLead))]
    public LeadEntity Lead { get; set; }
}


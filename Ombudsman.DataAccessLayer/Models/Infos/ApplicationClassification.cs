using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Ombudsman.DataAccessLayer.Models.Enums;

namespace Ombudsman.DataAccessLayer.Models.Infos;

[Table("info_application_classification", Schema = "ombudsman")]
public class ApplicationClassification
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("grouper")]
    public bool Grouper { get; set; }

    [Column("code")]
    [StringLength(15)]
    public string Code { get; set; } = null!;

    [Column("full_name")]
    [StringLength(500)]
    public string FullName { get; set; } = null!;

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("state_id")]
    public int StateId { get; set; }

    [Column("organization_id")]
    public int OrganizationId { get; set; }

    [Column("application_classification_id")]
    public int? ApplicationClassificationId { get; set; }

    [Column("organization_level_id")]
    public int OrganizationLevelId { get; set; }

    [ForeignKey("ApplicationClassificationId")]
    public virtual ApplicationClassification? ParentApplicationClassification { get; set; }

    public virtual ICollection<ApplicationClassification> InverseApplicationClassification { get; set; } = new List<ApplicationClassification>();

    [ForeignKey("OrganizationId")]
    public virtual Organization Organization { get; set; } = null!;

    [ForeignKey("OrganizationLevelId")]
    public virtual OrganizationLevel OrganizationLevel { get; set; } = null!;

    [ForeignKey("StateId")]
    public virtual State State { get; set; } = null!;
}

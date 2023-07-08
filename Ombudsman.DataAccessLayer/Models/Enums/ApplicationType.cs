using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Ombudsman.DataAccessLayer.Models.Docs;
using Ombudsman.DataAccessLayer.Models.Enums;

namespace Ombudsman.DataAccessLayer.Models;

[Table("enum_application_type", Schema = "ombudsman")]
public class ApplicationType
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("full_name")]
    [StringLength(500)]
    public string FullName { get; set; } = null!;

    [Column("short_name")]
    [StringLength(500)]
    public string ShortName { get; set; } = null!;

    [Column("state_id")]
    public int StateId { get; set; }

    public virtual ICollection<Application> DocApplications { get; set; } = new List<Application>();

    [ForeignKey("StateId")]
    public virtual State State { get; set; } = null!;
}


using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Ombudsman.DataAccessLayer.Models.Enums;
using Ombudsman.DataAccessLayer.Models.Docs;

namespace Ombudsman.DataAccessLayer.Models;

[Table("enum_business_sector", Schema = "ombudsman")]
public class BusinessSector
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

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    [ForeignKey("StateId")]
    public virtual State State { get; set; } = null!;
}


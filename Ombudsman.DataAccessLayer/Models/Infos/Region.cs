using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Ombudsman.DataAccessLayer.Models.Enums;
using Ombudsman.DataAccessLayer.Models.Docs;

namespace Ombudsman.DataAccessLayer.Models.Infos;

[Table("info_region", Schema = "ombudsman")]
public class Region
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("code")]
    [StringLength(3)]
    public string Code { get; set; } = null!;

    [Column("full_name")]
    [StringLength(500)]
    public string FullName { get; set; } = null!;

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("state_id")]
    public int StateId { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual ICollection<District> Districts { get; set; } = new List<District>();

    public virtual ICollection<Mfy> Mfies { get; set; } = new List<Mfy>();

    public virtual ICollection<Organization> Organizations { get; set; } = new List<Organization>();

    [ForeignKey("StateId")]
    public virtual State State { get; set; } = null!;
}


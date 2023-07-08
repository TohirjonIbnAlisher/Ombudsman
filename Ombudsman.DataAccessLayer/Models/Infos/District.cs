using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Ombudsman.DataAccessLayer.Models.Enums;
using Ombudsman.DataAccessLayer.Models.Docs;

namespace Ombudsman.DataAccessLayer.Models.Infos;

[Table("info_district", Schema = "ombudsman")]
public class District
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("code")]
    [StringLength(5)]
    public string Code { get; set; } = null!;

    [Column("full_name")]
    [StringLength(500)]
    public string FullName { get; set; } = null!;

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("region_id")]
    public int RegionId { get; set; }

    [Column("state_id")]
    public int StateId { get; set; }

    public virtual ICollection<Application> DocApplications { get; set; } = new List<Application>();

    public virtual ICollection<Mfy> InfoMfies { get; set; } = new List<Mfy>();

    public virtual ICollection<Organization> InfoOrganizations { get; set; } = new List<Organization>();

    [ForeignKey("RegionId")]
    public virtual Region Region { get; set; } = null!;

    [ForeignKey("StateId")]
    public virtual State State { get; set; } = null!;
}


using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Ombudsman.DataAccessLayer.Models.Enums;

namespace Ombudsman.DataAccessLayer.Models.Infos;

[Table("info_organization", Schema = "ombudsman")]
public class Organization
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("code")]
    [StringLength(10)]
    public string Code { get; set; } = null!;

    [Column("stir")]
    [StringLength(20)]
    public string Stir { get; set; } = null!;

    [Column("name")]
    [StringLength(500)]
    public string Name { get; set; } = null!;

    [Column("organization_type_id")]
    public int OrganizationTypeId { get; set; }

    [Column("organization_id")]
    public int? OrganizationId { get; set; }

    [Column("region_id")]
    public int RegionId { get; set; }

    [Column("district_id")]
    public int DistrictId { get; set; }

    [Column("organization_level_id")]
    public int OrganizationLevelId { get; set; }

    [Column("address")]
    [StringLength(500)]
    public string Address { get; set; } = null!;

    [Column("state_id")]
    public int StateId { get; set; }

    [ForeignKey("DistrictId")]
    public virtual District District { get; set; } = null!;

    [ForeignKey("OrganizationId")]
    public virtual Organization? ParentOrganization { get; set; }

    [ForeignKey("OrganizationLevelId")]
    public virtual OrganizationLevel OrganizationLevel { get; set; } = null!;

    [ForeignKey("OrganizationTypeId")]
    public virtual OrganizationType OrganizationType { get; set; } = null!;

    [ForeignKey("RegionId")]
    public virtual Region Region { get; set; } = null!;

    [ForeignKey("StateId")]
    public virtual State State { get; set; } = null!;
}


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ombudsman.DataAccessLayer.Postgre;

[Table("info_organization", Schema = "ombudsman")]
public partial class InfoOrganization
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
    [InverseProperty("InfoOrganizations")]
    public virtual InfoDistrict District { get; set; } = null!;

    [InverseProperty("Organization")]
    public virtual ICollection<InfoApplicationClassification> InfoApplicationClassifications { get; set; } = new List<InfoApplicationClassification>();

    [InverseProperty("Organization")]
    public virtual ICollection<InfoUserAccount> InfoUserAccounts { get; set; } = new List<InfoUserAccount>();

    [InverseProperty("Organization")]
    public virtual ICollection<InfoOrganization> InverseOrganization { get; set; } = new List<InfoOrganization>();

    [ForeignKey("OrganizationId")]
    [InverseProperty("InverseOrganization")]
    public virtual InfoOrganization? Organization { get; set; }

    [ForeignKey("OrganizationLevelId")]
    [InverseProperty("InfoOrganizations")]
    public virtual EnumOrganizationLevel OrganizationLevel { get; set; } = null!;

    [ForeignKey("OrganizationTypeId")]
    [InverseProperty("InfoOrganizations")]
    public virtual EnumOrganizationType OrganizationType { get; set; } = null!;

    [ForeignKey("RegionId")]
    [InverseProperty("InfoOrganizations")]
    public virtual InfoRegion Region { get; set; } = null!;

    [ForeignKey("StateId")]
    [InverseProperty("InfoOrganizations")]
    public virtual EnumState State { get; set; } = null!;
}

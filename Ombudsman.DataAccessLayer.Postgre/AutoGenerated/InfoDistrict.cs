using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ombudsman.DataAccessLayer.Postgre;

[Table("info_district", Schema = "ombudsman")]
public partial class InfoDistrict
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

    [InverseProperty("District")]
    public virtual ICollection<DocApplication> DocApplications { get; set; } = new List<DocApplication>();

    [InverseProperty("District")]
    public virtual ICollection<InfoMfy> InfoMfies { get; set; } = new List<InfoMfy>();

    [InverseProperty("District")]
    public virtual ICollection<InfoOrganization> InfoOrganizations { get; set; } = new List<InfoOrganization>();

    [ForeignKey("RegionId")]
    [InverseProperty("InfoDistricts")]
    public virtual InfoRegion Region { get; set; } = null!;

    [ForeignKey("StateId")]
    [InverseProperty("InfoDistricts")]
    public virtual EnumState State { get; set; } = null!;
}

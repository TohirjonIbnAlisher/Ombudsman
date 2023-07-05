using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ombudsman.DataAccessLayer.Postgre;

[Table("info_region", Schema = "ombudsman")]
public partial class InfoRegion
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

    [InverseProperty("Region")]
    public virtual ICollection<DocApplication> DocApplications { get; set; } = new List<DocApplication>();

    [InverseProperty("Region")]
    public virtual ICollection<InfoDistrict> InfoDistricts { get; set; } = new List<InfoDistrict>();

    [InverseProperty("Region")]
    public virtual ICollection<InfoMfy> InfoMfies { get; set; } = new List<InfoMfy>();

    [InverseProperty("Region")]
    public virtual ICollection<InfoOrganization> InfoOrganizations { get; set; } = new List<InfoOrganization>();

    [ForeignKey("StateId")]
    [InverseProperty("InfoRegions")]
    public virtual EnumState State { get; set; } = null!;
}

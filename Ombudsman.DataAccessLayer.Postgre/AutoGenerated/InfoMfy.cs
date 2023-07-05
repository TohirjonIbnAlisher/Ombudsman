using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ombudsman.DataAccessLayer.Postgre;

[Table("info_mfy", Schema = "ombudsman")]
public partial class InfoMfy
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("code")]
    [StringLength(10)]
    public string Code { get; set; } = null!;

    [Column("full_name")]
    [StringLength(500)]
    public string FullName { get; set; } = null!;

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("region_id")]
    public int RegionId { get; set; }

    [Column("district_id")]
    public int DistrictId { get; set; }

    [Column("state_id")]
    public int StateId { get; set; }

    [ForeignKey("DistrictId")]
    [InverseProperty("InfoMfies")]
    public virtual InfoDistrict District { get; set; } = null!;

    [InverseProperty("Mfy")]
    public virtual ICollection<DocApplication> DocApplications { get; set; } = new List<DocApplication>();

    [ForeignKey("RegionId")]
    [InverseProperty("InfoMfies")]
    public virtual InfoRegion Region { get; set; } = null!;

    [ForeignKey("StateId")]
    [InverseProperty("InfoMfies")]
    public virtual EnumState State { get; set; } = null!;
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ombudsman.DataAccessLayer.Postgre;

[Table("enum_business_sector", Schema = "ombudsman")]
public partial class EnumBusinessSector
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

    [InverseProperty("BusinessSector")]
    public virtual ICollection<DocApplication> DocApplications { get; set; } = new List<DocApplication>();

    [ForeignKey("StateId")]
    [InverseProperty("EnumBusinessSectors")]
    public virtual EnumState State { get; set; } = null!;
}

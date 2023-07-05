using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ombudsman.DataAccessLayer.Postgre;

[Table("enum_unit_of_measure", Schema = "ombudsman")]
public partial class EnumUnitOfMeasure
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("full_name")]
    [StringLength(500)]
    public string FullName { get; set; } = null!;

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("state_id")]
    public int StateId { get; set; }

    [InverseProperty("UnitOfMeasure")]
    public virtual ICollection<InfoParameter> InfoParameters { get; set; } = new List<InfoParameter>();

    [ForeignKey("StateId")]
    [InverseProperty("EnumUnitOfMeasures")]
    public virtual EnumState State { get; set; } = null!;
}

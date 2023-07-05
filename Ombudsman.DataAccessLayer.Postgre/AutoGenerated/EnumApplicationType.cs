using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ombudsman.DataAccessLayer.Postgre;

[Table("enum_application_type", Schema = "ombudsman")]
public partial class EnumApplicationType
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

    [InverseProperty("ApplicationType")]
    public virtual ICollection<DocApplication> DocApplications { get; set; } = new List<DocApplication>();

    [ForeignKey("StateId")]
    [InverseProperty("EnumApplicationTypes")]
    public virtual EnumState State { get; set; } = null!;
}

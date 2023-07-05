using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ombudsman.DataAccessLayer.Postgre;

[Table("enum_organization_level", Schema = "ombudsman")]
public partial class EnumOrganizationLevel
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

    [InverseProperty("OrganizationLevel")]
    public virtual ICollection<InfoApplicationClassification> InfoApplicationClassifications { get; set; } = new List<InfoApplicationClassification>();

    [InverseProperty("OrganizationLevel")]
    public virtual ICollection<InfoOrganization> InfoOrganizations { get; set; } = new List<InfoOrganization>();

    [ForeignKey("StateId")]
    [InverseProperty("EnumOrganizationLevels")]
    public virtual EnumState State { get; set; } = null!;
}

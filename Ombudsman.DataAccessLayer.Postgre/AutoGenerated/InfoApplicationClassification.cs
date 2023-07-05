using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ombudsman.DataAccessLayer.Postgre;

[Table("info_application_classification", Schema = "ombudsman")]
public partial class InfoApplicationClassification
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("grouper")]
    public bool Grouper { get; set; }

    [Column("code")]
    [StringLength(15)]
    public string Code { get; set; } = null!;

    [Column("full_name")]
    [StringLength(500)]
    public string FullName { get; set; } = null!;

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("state_id")]
    public int StateId { get; set; }

    [Column("organization_id")]
    public int OrganizationId { get; set; }

    [Column("application_classification_id")]
    public int? ApplicationClassificationId { get; set; }

    [Column("organization_level_id")]
    public int OrganizationLevelId { get; set; }

    [ForeignKey("ApplicationClassificationId")]
    [InverseProperty("InverseApplicationClassification")]
    public virtual InfoApplicationClassification? ApplicationClassification { get; set; }

    [InverseProperty("ApplicationClassification2")]
    public virtual ICollection<DocApplication> DocApplicationApplicationClassification2s { get; set; } = new List<DocApplication>();

    [InverseProperty("ApplicationClassification3")]
    public virtual ICollection<DocApplication> DocApplicationApplicationClassification3s { get; set; } = new List<DocApplication>();

    [InverseProperty("ApplicationClassification4")]
    public virtual ICollection<DocApplication> DocApplicationApplicationClassification4s { get; set; } = new List<DocApplication>();

    [InverseProperty("BaseApplicationClassification")]
    public virtual ICollection<DocApplication> DocApplicationBaseApplicationClassifications { get; set; } = new List<DocApplication>();

    [InverseProperty("ApplicationClassification")]
    public virtual ICollection<InfoApplicationClassification> InverseApplicationClassification { get; set; } = new List<InfoApplicationClassification>();

    [ForeignKey("OrganizationId")]
    [InverseProperty("InfoApplicationClassifications")]
    public virtual InfoOrganization Organization { get; set; } = null!;

    [ForeignKey("OrganizationLevelId")]
    [InverseProperty("InfoApplicationClassifications")]
    public virtual EnumOrganizationLevel OrganizationLevel { get; set; } = null!;

    [ForeignKey("StateId")]
    [InverseProperty("InfoApplicationClassifications")]
    public virtual EnumState State { get; set; } = null!;
}

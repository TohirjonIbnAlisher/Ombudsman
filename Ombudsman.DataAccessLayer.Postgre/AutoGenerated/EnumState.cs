using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ombudsman.DataAccessLayer.Postgre;

[Table("enum_state", Schema = "ombudsman")]
public partial class EnumState
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(10)]
    public string Name { get; set; } = null!;

    [InverseProperty("State")]
    public virtual ICollection<EnumApplicantType> EnumApplicantTypes { get; set; } = new List<EnumApplicantType>();

    [InverseProperty("State")]
    public virtual ICollection<EnumApplicationFormingType> EnumApplicationFormingTypes { get; set; } = new List<EnumApplicationFormingType>();

    [InverseProperty("State")]
    public virtual ICollection<EnumApplicationForm> EnumApplicationForms { get; set; } = new List<EnumApplicationForm>();

    [InverseProperty("State")]
    public virtual ICollection<EnumApplicationType> EnumApplicationTypes { get; set; } = new List<EnumApplicationType>();

    [InverseProperty("State")]
    public virtual ICollection<EnumBusinessSector> EnumBusinessSectors { get; set; } = new List<EnumBusinessSector>();

    [InverseProperty("State")]
    public virtual ICollection<EnumDirectory> EnumDirectories { get; set; } = new List<EnumDirectory>();

    [InverseProperty("State")]
    public virtual ICollection<EnumEmploymentType> EnumEmploymentTypes { get; set; } = new List<EnumEmploymentType>();

    [InverseProperty("State")]
    public virtual ICollection<EnumOrganizationLevel> EnumOrganizationLevels { get; set; } = new List<EnumOrganizationLevel>();

    [InverseProperty("State")]
    public virtual ICollection<EnumOrganizationType> EnumOrganizationTypes { get; set; } = new List<EnumOrganizationType>();

    [InverseProperty("State")]
    public virtual ICollection<EnumParameterType> EnumParameterTypes { get; set; } = new List<EnumParameterType>();

    [InverseProperty("State")]
    public virtual ICollection<EnumPosition> EnumPositions { get; set; } = new List<EnumPosition>();

    [InverseProperty("State")]
    public virtual ICollection<EnumRole> EnumRoles { get; set; } = new List<EnumRole>();

    [InverseProperty("State")]
    public virtual ICollection<EnumUnitOfMeasure> EnumUnitOfMeasures { get; set; } = new List<EnumUnitOfMeasure>();

    [InverseProperty("State")]
    public virtual ICollection<InfoApplicationClassification> InfoApplicationClassifications { get; set; } = new List<InfoApplicationClassification>();

    [InverseProperty("State")]
    public virtual ICollection<InfoDistrict> InfoDistricts { get; set; } = new List<InfoDistrict>();

    [InverseProperty("State")]
    public virtual ICollection<InfoMfy> InfoMfies { get; set; } = new List<InfoMfy>();

    [InverseProperty("State")]
    public virtual ICollection<InfoOrganization> InfoOrganizations { get; set; } = new List<InfoOrganization>();

    [InverseProperty("State")]
    public virtual ICollection<InfoParameter> InfoParameters { get; set; } = new List<InfoParameter>();

    [InverseProperty("State")]
    public virtual ICollection<InfoRegion> InfoRegions { get; set; } = new List<InfoRegion>();

    [InverseProperty("State")]
    public virtual ICollection<InfoUserAccount> InfoUserAccounts { get; set; } = new List<InfoUserAccount>();
}

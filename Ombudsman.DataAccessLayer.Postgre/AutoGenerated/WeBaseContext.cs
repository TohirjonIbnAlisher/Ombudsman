using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Ombudsman.DataAccessLayer.Postgre;

public partial class WeBaseContext : DbContext
{
    public WeBaseContext()
    {
    }

    public WeBaseContext(DbContextOptions<WeBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DocApplication> DocApplications { get; set; }

    public virtual DbSet<EnumApplicantType> EnumApplicantTypes { get; set; }

    public virtual DbSet<EnumApplicationForm> EnumApplicationForms { get; set; }

    public virtual DbSet<EnumApplicationFormingType> EnumApplicationFormingTypes { get; set; }

    public virtual DbSet<EnumApplicationType> EnumApplicationTypes { get; set; }

    public virtual DbSet<EnumBusinessSector> EnumBusinessSectors { get; set; }

    public virtual DbSet<EnumDirectory> EnumDirectories { get; set; }

    public virtual DbSet<EnumEmploymentType> EnumEmploymentTypes { get; set; }

    public virtual DbSet<EnumOrganizationLevel> EnumOrganizationLevels { get; set; }

    public virtual DbSet<EnumOrganizationType> EnumOrganizationTypes { get; set; }

    public virtual DbSet<EnumParameterType> EnumParameterTypes { get; set; }

    public virtual DbSet<EnumPosition> EnumPositions { get; set; }

    public virtual DbSet<EnumRole> EnumRoles { get; set; }

    public virtual DbSet<EnumState> EnumStates { get; set; }

    public virtual DbSet<EnumStatus> EnumStatuses { get; set; }

    public virtual DbSet<EnumUnitOfMeasure> EnumUnitOfMeasures { get; set; }

    public virtual DbSet<InfoApplicationClassification> InfoApplicationClassifications { get; set; }

    public virtual DbSet<InfoDistrict> InfoDistricts { get; set; }

    public virtual DbSet<InfoMfy> InfoMfies { get; set; }

    public virtual DbSet<InfoOrganization> InfoOrganizations { get; set; }

    public virtual DbSet<InfoParameter> InfoParameters { get; set; }

    public virtual DbSet<InfoRegion> InfoRegions { get; set; }

    public virtual DbSet<InfoUserAccount> InfoUserAccounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=ibnAlisher7379;Database=WeBase");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
       
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

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
        modelBuilder.Entity<DocApplication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doc_application_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.ApplicationClassification2).WithMany(p => p.DocApplicationApplicationClassification2s)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_application_classification_2");

            entity.HasOne(d => d.ApplicationClassification3).WithMany(p => p.DocApplicationApplicationClassification3s)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_application_classification_3");

            entity.HasOne(d => d.ApplicationClassification4).WithMany(p => p.DocApplicationApplicationClassification4s)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_application_classification_4");

            entity.HasOne(d => d.ApplicationType).WithMany(p => p.DocApplications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_application_type");

            entity.HasOne(d => d.BaseApplicationClassification).WithMany(p => p.DocApplicationBaseApplicationClassifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_base_application_classification");

            entity.HasOne(d => d.BusinessSector).WithMany(p => p.DocApplications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_business_sector");

            entity.HasOne(d => d.District).WithMany(p => p.DocApplications).HasConstraintName("fk_district");

            entity.HasOne(d => d.Mfy).WithMany(p => p.DocApplications).HasConstraintName("fk_mfy");

            entity.HasOne(d => d.Region).WithMany(p => p.DocApplications).HasConstraintName("fk_region");
        });

        modelBuilder.Entity<EnumApplicantType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("applicant_type_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.State).WithMany(p => p.EnumApplicantTypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state");
        });

        modelBuilder.Entity<EnumApplicationForm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("application_form_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.State).WithMany(p => p.EnumApplicationForms)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state");
        });

        modelBuilder.Entity<EnumApplicationFormingType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("application_forming_type_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.State).WithMany(p => p.EnumApplicationFormingTypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state");
        });

        modelBuilder.Entity<EnumApplicationType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("application_type_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.State).WithMany(p => p.EnumApplicationTypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state");
        });

        modelBuilder.Entity<EnumBusinessSector>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("business_sector_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.State).WithMany(p => p.EnumBusinessSectors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state");
        });

        modelBuilder.Entity<EnumDirectory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_directory_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.State).WithMany(p => p.EnumDirectories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state");
        });

        modelBuilder.Entity<EnumEmploymentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employment_type_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.State).WithMany(p => p.EnumEmploymentTypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state");
        });

        modelBuilder.Entity<EnumOrganizationLevel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("organization_level_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.State).WithMany(p => p.EnumOrganizationLevels)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state");
        });

        modelBuilder.Entity<EnumOrganizationType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("organization_type_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.State).WithMany(p => p.EnumOrganizationTypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state");
        });

        modelBuilder.Entity<EnumParameterType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("parameter_types_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.State).WithMany(p => p.EnumParameterTypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state");
        });

        modelBuilder.Entity<EnumPosition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("position_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.State).WithMany(p => p.EnumPositions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state");
        });

        modelBuilder.Entity<EnumRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("role_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.State).WithMany(p => p.EnumRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state");
        });

        modelBuilder.Entity<EnumState>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("state_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<EnumStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_status_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<EnumUnitOfMeasure>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("enum_unit_of_measure_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.State).WithMany(p => p.EnumUnitOfMeasures)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state");
        });

        modelBuilder.Entity<InfoApplicationClassification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_application_classification_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.ApplicationClassification).WithMany(p => p.InverseApplicationClassification).HasConstraintName("fk_application_classification");

            entity.HasOne(d => d.Organization).WithMany(p => p.InfoApplicationClassifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_organization");

            entity.HasOne(d => d.OrganizationLevel).WithMany(p => p.InfoApplicationClassifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_organization_level");

            entity.HasOne(d => d.State).WithMany(p => p.InfoApplicationClassifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state");
        });

        modelBuilder.Entity<InfoDistrict>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_district_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Region).WithMany(p => p.InfoDistricts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_region");

            entity.HasOne(d => d.State).WithMany(p => p.InfoDistricts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state");
        });

        modelBuilder.Entity<InfoMfy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_mfy_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.District).WithMany(p => p.InfoMfies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_district");

            entity.HasOne(d => d.Region).WithMany(p => p.InfoMfies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_region");

            entity.HasOne(d => d.State).WithMany(p => p.InfoMfies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state");
        });

        modelBuilder.Entity<InfoOrganization>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_organization_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.District).WithMany(p => p.InfoOrganizations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_district");

            entity.HasOne(d => d.Organization).WithMany(p => p.InverseOrganization).HasConstraintName("fk_organization");

            entity.HasOne(d => d.OrganizationLevel).WithMany(p => p.InfoOrganizations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_organization_level");

            entity.HasOne(d => d.OrganizationType).WithMany(p => p.InfoOrganizations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_organization_type");

            entity.HasOne(d => d.Region).WithMany(p => p.InfoOrganizations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_region");

            entity.HasOne(d => d.State).WithMany(p => p.InfoOrganizations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state");
        });

        modelBuilder.Entity<InfoParameter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_parameters_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Directory).WithMany(p => p.InfoParameters).HasConstraintName("fk_directory");

            entity.HasOne(d => d.State).WithMany(p => p.InfoParameters)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state");

            entity.HasOne(d => d.UnitOfMeasure).WithMany(p => p.InfoParameters).HasConstraintName("fk_unit_of_measure");
        });

        modelBuilder.Entity<InfoRegion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("info_region_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.State).WithMany(p => p.InfoRegions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state");
        });

        modelBuilder.Entity<InfoUserAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_account_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Organization).WithMany(p => p.InfoUserAccounts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_organization");

            entity.HasOne(d => d.Position).WithMany(p => p.InfoUserAccounts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_position");

            entity.HasOne(d => d.Role).WithMany(p => p.InfoUserAccounts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_role");

            entity.HasOne(d => d.State).WithMany(p => p.InfoUserAccounts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_state");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

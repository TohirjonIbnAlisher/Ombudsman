using Microsoft.EntityFrameworkCore;
using Ombudsman.DataAccessLayer.Models;
using Ombudsman.DataAccessLayer.Models.Docs;
using Ombudsman.DataAccessLayer.Models.Enums;
using Ombudsman.DataAccessLayer.Models.Infos;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ombudsman.DataAccessLayer.DBContext;

public class OmbudsmanDBContext : DbContext
{
    public OmbudsmanDBContext()
    {
    }

    public OmbudsmanDBContext(DbContextOptions<OmbudsmanDBContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<ApplicantType> ApplicantTypes { get; set; }

    public virtual DbSet<ApplicationForm> ApplicationForms { get; set; }

    public virtual DbSet<ApplicationFormingType> ApplicationFormingTypes { get; set; }

    public virtual DbSet<ApplicationType> ApplicationTypes { get; set; }

    public virtual DbSet<BusinessSector> BusinessSectors { get; set; }

    public virtual DbSet<SysTable> Directories { get; set; }

    public virtual DbSet<EmploymentType> EmploymentTypes { get; set; }

    public virtual DbSet<OrganizationLevel> OrganizationLevels { get; set; }

    public virtual DbSet<OrganizationType> OrganizationTypes { get; set; }

    public virtual DbSet<ParameterType> ParameterTypes { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }

    public virtual DbSet<ApplicationClassification> ApplicationClassifications { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<Mfy> Mfies { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<Parameter> Parameters { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<UserAccount> UserAccounts { get; set; }

    public virtual DbSet<PermissionRole> PermissionRoles { get; set; }
    public virtual DbSet<Permission> Permission { get; set; }
    public virtual DbSet<AppilcationParam> AppilcationParam { get; set; }
    public virtual DbSet<ApplicationClassificationParameter> ApplicationClassificationParameter { get; set; }




}

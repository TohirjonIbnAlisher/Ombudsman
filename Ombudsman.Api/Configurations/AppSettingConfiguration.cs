using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Ombudsman.BizLogic.Attributes.ControllerAttributes;
using Ombudsman.BizLogic.MappingProfiles;
using Ombudsman.BizLogic.Services.ApplicationClassificationServices;
using Ombudsman.BizLogic.Services.AuthenticationServices;
using Ombudsman.BizLogic.Services.DistrictServices;
using Ombudsman.BizLogic.Services.ManualServices;
using Ombudsman.BizLogic.Services.MfyServices;
using Ombudsman.BizLogic.Services.OrganizationServices;
using Ombudsman.BizLogic.Services.RegionServices;
using Ombudsman.BizLogic.Services.UserAccountservices;
using Ombudsman.DataAccessLayer.Authentications;
using Ombudsman.DataAccessLayer.DBContext;
using Ombudsman.DataAccessLayer.Repositories;
using Ombudsman.DataAccessLayer.Repositories.ApplicantTypes;
using Ombudsman.DataAccessLayer.Repositories.ApplicationClassifacitaions;
using Ombudsman.DataAccessLayer.Repositories.ApplicationFormingTypes;
using Ombudsman.DataAccessLayer.Repositories.ApplicationForms;
using Ombudsman.DataAccessLayer.Repositories.ApplicationTypes;
using Ombudsman.DataAccessLayer.Repositories.BusinessSectors;
using Ombudsman.DataAccessLayer.Repositories.Districts;
using Ombudsman.DataAccessLayer.Repositories.EmploymentTypes;
using Ombudsman.DataAccessLayer.Repositories.Mfys;
using Ombudsman.DataAccessLayer.Repositories.OrganizationLevels;
using Ombudsman.DataAccessLayer.Repositories.Organizations;
using Ombudsman.DataAccessLayer.Repositories.OrganizationTypes;
using Ombudsman.DataAccessLayer.Repositories.ParameterTypes;
using Ombudsman.DataAccessLayer.Repositories.Regions;
using Ombudsman.DataAccessLayer.Repositories.States;
using Ombudsman.DataAccessLayer.Repositories.UnitOfMeasures;
using Ombudsman.DataAccessLayer.Repositories.UserAccounts;
using System.Text;

namespace Ombudsman.Api.Configurations;

public static class AppSettingConfiguration
{
    public static IServiceCollection AddConnectionString(
        this WebApplicationBuilder webApplicationBuilder)
    {
        webApplicationBuilder.Services.AddDbContext<OmbudsmanDBContext>(option =>
            option.UseNpgsql(webApplicationBuilder.Configuration.GetConnectionString("DefaultConnectionStrings")));

        webApplicationBuilder.Services
            .AddScoped<IOrganizationServices, OrganizationService>()
            .AddScoped<IUserAccountService, UserAccountService>()
            .AddScoped<IRegionService, RegionService>()
            .AddScoped<IDistrictService, DistrictService>()
            .AddScoped<IMfyService, MfyService>()
            .AddScoped<IApplicationClassificationService, ApplicationClassificationService>()
            .AddScoped<IAuthenticationService, AuthenticationService>()
            .AddScoped<IManualService, ManualService>()
            .AddTransient<IAuthorizationHandler, PermissionAuthorizationHandler>()
            .AddTransient<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();
            

        webApplicationBuilder.Services
            .AddScoped<IOrganizationRepository, OrganizationRepository>()
            .AddScoped<IUserAccountRepository, UserAccountRepository>()
            .AddScoped<IRegionRepository, RegionRepository>()
            .AddScoped<IDistrictRepository, DistrictRepository>()
            .AddScoped<IMfyRepository, MfyRepository>()
            .AddScoped<IApplicationClassificationRepository, ApplicationClassificationRepository>()
            .AddScoped<IOrganizationLevelRepository, OrganizationLevelRepository>()
            .AddScoped<IParameterTypeRepository, ParameterTypeRepository>()
            .AddScoped<IApplicationTypeRepository, ApplicationTypeRepository>()
            .AddScoped<IApplicationFormRepository, ApplicationFormRepository>()
            .AddScoped<IApplicationFormingTypeRepository, ApplicationFormingTypeRepository>()
            .AddScoped<IApplicantTypeRepository, ApplicantTypeRepository>()
            .AddScoped<IEmploymentTypeRepository, EmploymentTypeRepository>()
            .AddScoped<IBusinessSectorRepository, BusinessSectorRepository>()
            .AddScoped<IOrganizationTypeRepository, OrganizationTypeRepository>()
            .AddScoped<IUnitOfMeasureRepository, UnitOfMeasureRepository>()
            .AddScoped<IJwtTokenGeneration, JwtTokenGeneration>()
            .AddScoped<IPasswordGeneration, PasswordGeneration>()
            .AddScoped<IStateRepository, StateRepository>();

        webApplicationBuilder.Services.AddAutoMapper(typeof(OrganizationMapping));


        // ConfigureJwt

        var _config = webApplicationBuilder.Configuration.GetSection("JwtSettings");
        webApplicationBuilder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = _config["Issuer"],
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecretKey"]))
                };
            });

        webApplicationBuilder.Services.Configure<JwtOption>(webApplicationBuilder.Configuration.GetSection("JwtSettings"));


        // ConfigureSwaggerAuthorize

        webApplicationBuilder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ombudsman.Api", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description =
                    "JWT Authorization header using the Bearer scheme. " +
                    "Example: \"Authorization: Bearer {token}\"",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
        });
        return webApplicationBuilder.Services;
    }
}

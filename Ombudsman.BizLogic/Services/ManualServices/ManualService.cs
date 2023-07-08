using AutoMapper;
using Ombudsman.BizLogic.DataTransferObjects.ManuallyDTOs;
using Ombudsman.DataAccessLayer.Models;
using Ombudsman.DataAccessLayer.Models.Enums;
using Ombudsman.DataAccessLayer.Repositories;
using Ombudsman.DataAccessLayer.Repositories.ApplicantTypes;
using Ombudsman.DataAccessLayer.Repositories.ApplicationFormingTypes;
using Ombudsman.DataAccessLayer.Repositories.ApplicationForms;
using Ombudsman.DataAccessLayer.Repositories.BusinessSectors;
using Ombudsman.DataAccessLayer.Repositories.EmploymentTypes;
using Ombudsman.DataAccessLayer.Repositories.OrganizationLevels;
using Ombudsman.DataAccessLayer.Repositories.OrganizationTypes;
using Ombudsman.DataAccessLayer.Repositories.Parameters;
using Ombudsman.DataAccessLayer.Repositories.ParameterTypes;
using Ombudsman.DataAccessLayer.Repositories.States;
using Ombudsman.DataAccessLayer.Repositories.UnitOfMeasures;

namespace Ombudsman.BizLogic.Services.ManualServices;

public class ManualService : IManualService
{
    private readonly IApplicationFormingTypeRepository _applicationFormingTypeRepository;
    private readonly IApplicationFormRepository _applicationFormRepository;
    private readonly IApplicantTypeRepository _applicantTypeRepository;
    private readonly IApplicationTypeRepository _applicationTypeRepository;
    private readonly IBusinessSectorRepository _businessSectorRepository;
    private readonly IOrganizationLevelRepository _organizationLevelRepository;
    private readonly IOrganizationTypeRepository _organizationTypeRepository;
    private readonly IEmploymentTypeRepository _employmentTypeRepository;
    private readonly IParameterTypeRepository _parameterTypeRepository;
    private readonly IStateRepository _stateRepository;
    private readonly IUnitOfMeasureRepository _unitOfMeasureRepository;
    private readonly IMapper _mapper;

    public ManualService(
        IApplicationFormingTypeRepository applicationFormingTypeRepository,
        IApplicationFormRepository applicationFormRepository,
        IApplicantTypeRepository applicantTypeRepository,
        IApplicationTypeRepository applicationTypeRepository,
        IBusinessSectorRepository businessSectorRepository,
        IOrganizationLevelRepository organizationLevelRepository,
        IEmploymentTypeRepository employmentTypeRepository,
        IParameterTypeRepository parameterTypeRepository,
        IOrganizationTypeRepository organizationTypeRepository,
        IMapper mapper,
        IStateRepository stateRepository,
        IUnitOfMeasureRepository unitOfMeasureRepository)
    {
        _applicationFormingTypeRepository = applicationFormingTypeRepository;
        _applicationFormRepository = applicationFormRepository;
        _applicantTypeRepository = applicantTypeRepository;
        _applicationTypeRepository = applicationTypeRepository;
        _businessSectorRepository = businessSectorRepository;
        _organizationLevelRepository = organizationLevelRepository;
        _employmentTypeRepository = employmentTypeRepository;
        _parameterTypeRepository = parameterTypeRepository;
        _organizationTypeRepository = organizationTypeRepository;
        _mapper = mapper;
        _stateRepository = stateRepository;
        _unitOfMeasureRepository = unitOfMeasureRepository;
    }

    public IQueryable<ManualDTO> RetrieveApplicantTypes()
    {
        var selectedAppTypes = _applicantTypeRepository.SelectAllEntity(new string[] {});

        return selectedAppTypes.Select(appType => _mapper.Map<ApplicantType, ManualDTO>(appType));
    }

    public IQueryable<ManualDTO> RetrieveApplicationFormingTypes()
    {
        var selectedAppTypes = _applicationFormingTypeRepository.SelectAllEntity(new string[] { });

        return selectedAppTypes.Select(appFormType => _mapper.Map<ApplicationFormingType, ManualDTO>(appFormType));
    }

    public IQueryable<ManualDTO> RetrieveApplicationForms()
    {
        var selectedAppTypes = _applicationFormRepository.SelectAllEntity(new string[] { });

        return selectedAppTypes.Select(appForm => _mapper.Map<ApplicationForm, ManualDTO>(appForm));
    }

    public IQueryable<ManualDTO> RetrieveApplicationTypes()
    {
        var selectedAppTypes = _applicationTypeRepository.SelectAllEntity(new string[] { });

        return selectedAppTypes.Select(applicatType => _mapper.Map<ApplicationType, ManualDTO>(applicatType));
    }

    public IQueryable<ManualDTO> RetrieveBusinessSector()
    {
        var selectedBussSector = _businessSectorRepository.SelectAllEntity(new string[] { });

        return selectedBussSector.Select(bs => _mapper.Map<BusinessSector, ManualDTO>(bs));
    }

    public IQueryable<ManualDTO> RetrieveEmploymentTypes()
    {
        var selectedEmpType = _employmentTypeRepository.SelectAllEntity(new string[] { });

        return selectedEmpType.Select(empType => _mapper.Map<EmploymentType, ManualDTO>(empType));
    }

    public IQueryable<ManualDTO> RetrieveOrganizationLevels()
    {
        var selectedOrgLevel = _organizationLevelRepository.SelectAllEntity(new string[] { });

        return selectedOrgLevel.Select(orgL => _mapper.Map<OrganizationLevel, ManualDTO>(orgL));
    }
    
    public IQueryable<ManualDTO> RetrieveOrganizationTypes()
    {
        var selectedOrgLevel =_organizationTypeRepository.SelectAllEntity(new string[] { });

        return selectedOrgLevel.Select(orgT => _mapper.Map<OrganizationType, ManualDTO>(orgT));
    }

    public IQueryable<ManualDTO> RetrieveParameterTypes()
    {
        var selectedParamTypes = _parameterTypeRepository.SelectAllEntity(new string[] { });

        return selectedParamTypes.Select(parType => _mapper.Map<ParameterType, ManualDTO>(parType));
    }
    public IQueryable<ManualDTO> RetrieveStates()
    {
        var selectedParamTypes = _stateRepository.SelectAllEntity(new string[] { });

        return selectedParamTypes.Select(parType => _mapper.Map<State, ManualDTO>(parType));
    }
    
    public IQueryable<ManualDTO> RetrieveUnitOfMeasures()
    {
        var selectedParamTypes = _unitOfMeasureRepository.SelectAllEntity(new string[] { });

        return selectedParamTypes.Select(parType => _mapper.Map<UnitOfMeasure, ManualDTO>(parType));
    }
}

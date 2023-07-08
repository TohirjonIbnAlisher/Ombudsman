using Ombudsman.BizLogic.DataTransferObjects;
using Ombudsman.BizLogic.DataTransferObjects.ManuallyDTOs;

namespace Ombudsman.BizLogic.Services.ManualServices;

public interface IManualService
{
    IQueryable<ManualDTO> RetrieveApplicationTypes();
    IQueryable<ManualDTO> RetrieveApplicantTypes();
    IQueryable<ManualDTO> RetrieveBusinessSector();
    IQueryable<ManualDTO> RetrieveEmploymentTypes();
    IQueryable<ManualDTO> RetrieveApplicationForms();
    IQueryable<ManualDTO> RetrieveApplicationFormingTypes();
    IQueryable<ManualDTO> RetrieveParameterTypes();
    IQueryable<ManualDTO> RetrieveOrganizationLevels();
    IQueryable<ManualDTO> RetrieveOrganizationTypes();
    IQueryable<ManualDTO> RetrieveStates();
    IQueryable<ManualDTO> RetrieveUnitOfMeasures();
}

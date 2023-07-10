namespace Ombudsman.DataAccessLayer.Models.SystemEnums;

public enum PermissionEnums
{
    // ApplicationClassification
    PostApplicationClassificationAsync,
    PutApplicationClassificationAsync,
    GetApplicationClassificationByIdAsync,
    GetAllApplicationClassifications,
    Get,
    DeleteApplicationClassificationAsync,

    // District
    PostDistrictAsync,
    PutDistrictAsync,
    GetDistrictByIdAsync,
    GetAllDistricts,
    //Get,
    DeleteDistrictAsync,

    // Manual
    GetEmploymentTypes,
    GetBusinessSectors,
    GetApplicantTypes,
    GetApplicationFormingTypes,
    GetApplicationForms,
    GetApplicationTypes,
    GetOrganizationLevels,
    GetOrganizationTypes,
    GetParameterTypes,
    GetStates,
    GetUnitOfMeasures,

    // Mfy
    PostMfyAsync,
    PutMfyAsync,
    GetMfyByIdAsync,
    GetAllMfys,
    // Get,
    DeleteMfyAsync,

    // Organization
    PostOrganizationAsync,
    PutOrganizationAsync,
    GetOrganizationByIdAsync,
    GetAllOrganizations,
    // Get,
    DeleteOrganizationAsync,

    // Region
    PostRegionAsync,
    PutRegionAsync,
    GetRegionByIdAsync,
    GetAllRegions,
    // Get,
    DeleteRegionAsync,

    // UserAccount
    PostUserAccountAsync,
    PutUserAccountAsync,
    GetUserAccountByIdAsync,
    GetAllUserAccounts,
    //Get(),
    DeleteUserAccountAsync,

    // AssigningPermission
    PostAssigningPermissionAsync,
    PutAssigningPermissionAsync,
    GetAssigningPermissionByIdAsync,
    GetAllAssigningPermissions,
    DeleteAssigningPermissionAsync,


    // ApplicationClassificationParam
    PostApplicationClassificationParamAsync,
    PutApplicationClassificationParamAsync,
    GetApplicationClassificationParamByIdAsync,
    GetAllApplicationClassificationParams,

    //Application
    PostApplicationAsync,
    PutApplicationAsync,
    GetApplicationByIdAsync,
    GetAllApplications,
    DeleteApplicationAsync,

    // ApplicationParameter

    PostApplicationParameterAsync,
    PutApplicationParameterAsync,
    GetApplicationParameterByIdAsync,
    GetAllApplicationParameters,

    // Parameter

    PostParameterAsync,
    GetParameterByIdAsync,
    GetAllParameters,
    DeleteParameterAsync,


}

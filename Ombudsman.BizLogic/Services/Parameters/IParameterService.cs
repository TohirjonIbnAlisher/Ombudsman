using Ombudsman.BizLogic.DataTransferObjects.ParameterDTOs;

namespace Ombudsman.BizLogic.Services.Parameters;

public interface IParameterService
{
    ValueTask<GetParameterDTO> CreateDigNumParameterAsync(CreationDigNumParameterDTO creationDigNumParameterDTO);
    ValueTask<GetParameterDTO> CreateSanaParameterAsync(CreationSanaParameterDTO creationSanaParameterDTO);
    ValueTask<GetParameterDTO> CreateSpravochnikParameterAsync(CreationSpravochnikParameterDTO creationSpravochnikParameterDTO);
    ValueTask<GetParameterDTO> CreateTellNumParameterAsync(CreationTellNumParameterDTO creationTellNumParameterDTO);

    IQueryable<GetParameterDTO> RetrieveParameters();

    ValueTask<GetParameterDTO> RetrieveParameterByIdAsync(int id);


    ValueTask<GetParameterDTO> RemoveParameterAsync(int id);
    GetParameterDTO RetrieveAsync();
}

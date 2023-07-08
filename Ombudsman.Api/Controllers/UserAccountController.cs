using Microsoft.AspNetCore.Mvc;
using Ombudsman.BizLogic.DataTransferObjects.UserAccountDTOs;
using Ombudsman.BizLogic.Services.UserAccountservices;

namespace Ombudsman.Api.Controllers
{
    [Route("api/userAccount")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserAccountService userAccountService;

        public UserAccountController(IUserAccountService userAccountService)
        {
            this.userAccountService = userAccountService;
        }

        [HttpPost]
        public async ValueTask<IActionResult> PostUserAccountAsync(
            CreationUserAccountDTO creationUserAccountDTO)
            => Created("", await this.userAccountService.CreateUserAccountAsync(creationUserAccountDTO));

        [HttpPut("{id}")]
        public async ValueTask<IActionResult> PutUserAccountAsync(
            int id,
            ModifyUserAccountDTO modifyUserAccountDTO)
            => Ok(await this.userAccountService.ModifyUserAccountAsync(id, modifyUserAccountDTO));

        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetUserAccountByIdAsync(int id)
            => Ok(await this.userAccountService.RetrieveUserAccountByIdAsync(id));

        [HttpGet("selectedList")]
        public IActionResult GetAllUserAccounts()
            => Ok(this.userAccountService.RetrieveUserAccounts());

        [HttpGet]
        public IActionResult Get()
            => Ok(this.userAccountService.RetrieveAsync());

        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteUserAccountAsync(int id)
            => Ok(await this.userAccountService.RemoveUserAccountAsync(id));
    }
}

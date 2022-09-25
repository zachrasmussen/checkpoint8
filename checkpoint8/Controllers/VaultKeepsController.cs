using System;
using System.Threading.Tasks;
using checkpoint8.Models;
using checkpoint8.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace checkpoint8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaultKeepsController : ControllerBase
    {
        private readonly VaultKeepsService _vkService;
        public VaultKeepsController(VaultKeepsService vkService)
        {
            _vkService = vkService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<VaultKeepsViewModel>> Create([FromBody] VaultKeep newVaultKeep)
        {
            try
            {
                Account user = await HttpContext.GetUserInfoAsync<Account>();
                VaultKeepViewModel keep = _vkService.Create(newVaultKeep, user.Id);
                return Ok(keep);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id")]
        [Authorize]
        public async Task<ActionResult<string>> Delete(int id)
        {
            try
            {
                Account user = await HttpContext.GetUserInfoAsync<Account>();
                return _vkService.Delete(id, user)
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
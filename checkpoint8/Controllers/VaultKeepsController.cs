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
        public async Task<ActionResult<VaultKeep>> Create([FromBody] VaultKeep vaultKeepData)
        {
            try
            {
                Account user = await HttpContext.GetUserInfoAsync<Account>();
                vaultKeepData.CreatorId = user.Id;
                VaultKeep vaultKeep = _vkService.Create(vaultKeepData);
                return Ok(vaultKeep);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Authorize]

        public Task<ActionResult<VaultKeep>> GetById([FromBody] VaultKeep vaultKeepData)
        {
            try
            {

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // [HttpDelete("{id")]
        // [Authorize]
        // public async Task<ActionResult<string>> Delete(int id)
        // {
        //     try
        //     {
        //         Account user = await HttpContext.GetUserInfoAsync<Account>();
        //         return _vkService.Delete(id, user);
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }
    }
}
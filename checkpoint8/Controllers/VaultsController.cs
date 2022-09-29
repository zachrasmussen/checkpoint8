using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using checkpoint8.Models;
using checkpoint8.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static checkpoint8.Models.Keep;

namespace checkpoint8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaultsController : ControllerBase
    {
        private readonly VaultsService _vService;
        private readonly VaultKeepsService _vkService;

        public VaultsController(VaultsService vService, VaultKeepsService vkService)
        {
            _vService = vService;
            _vkService = vkService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Vault>> Create([FromBody] Vault vaultData)
        {
            try
            {
                Account user = await HttpContext.GetUserInfoAsync<Account>();
                vaultData.CreatorId = user.Id;
                Vault vault = _vService.Create(vaultData);
                vault.Creator = user;
                return Ok(vault);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vault>> GetById(int id)
        {
            try
            {
                Account user = await HttpContext.GetUserInfoAsync<Account>();
                Vault vault = _vService.GetById(id, user?.Id);
                return Ok(vault);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Vault>> Update(int id, [FromBody] Vault vaultData)
        {
            try
            {
                Account user = await HttpContext.GetUserInfoAsync<Account>();
                vaultData.Id = id;
                Vault vault = _vService.Update(vaultData, user);
                return Ok(vault);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<string>> Delete(int id)
        {
            try
            {
                Account user = await HttpContext.GetUserInfoAsync<Account>();
                string message = _vService.Delete(id, user);
                return Ok(message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/keeps")]
        public async Task<ActionResult<List<VaultKeepViewModel>>> GetKeeps(int id)
        {
            try
            {
                Account user = await HttpContext.GetUserInfoAsync<Account>();
                List<VaultKeepViewModel> keeps = _vkService.GetKeepsByVaultId(id, user?.Id);
                return Ok(keeps);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using checkpoint8.Models;
using checkpoint8.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace checkpoint8.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;
        private readonly VaultsService _vService;

        public AccountController(AccountService accountService, VaultsService vService)
        {
            _accountService = accountService;
            _vService = vService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<Account>> Get()
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                return Ok(_accountService.GetOrCreateProfile(userInfo));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("vaults")]
        [Authorize]
        public async Task<ActionResult<List<Vault>>> GetVaultsByProfile(string id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                List<Vault> vaults = _vService.GetMyVaults(userInfo.Id);
                return Ok(vaults);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // [HttpGet("/vaults")]
        // [Authorize]
        // public async Task<ActionResult<List<Vault>>> GetVaultsByAccount(string id)
        // {
        //     try
        //     {
        //         Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        //         return _vService.GetMyVaults(id);
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }
    }


}
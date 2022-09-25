using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using checkpoint8.Models;
using checkpoint8.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Mvc;

namespace checkpoint8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly ProfilesService _pService;
        private readonly KeepsService _kService;
        private readonly VaultsService _vService;
        public ProfilesController(ProfilesService pService, KeepsService kService, VaultsService vService)
        {
            _pService = pService;
            _kService = kService;
            _vService = vService;
        }

        [HttpGet("{id")]
        public ActionResult<ProfilesController> Get(string id)
        {
            try
            {
                return _pService.Get(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/keeps")]
        public ActionResult<List<Keep>> GetKeepsByProfile(string id)
        {
            try
            {
                List<Keep> keeps = _kService.GetKeepsByProfile(id);
                return keeps;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/vaults")]
        public async Task<ActionResult<List<Vault>>> GetVaultsByProfile(string id)
        {
            try
            {
                Account user = await HttpContext.GetUserInfoAsync<Account>();
                return _vService.GetVaultsByProfile(id, user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
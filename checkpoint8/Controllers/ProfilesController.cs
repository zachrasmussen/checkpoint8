using System;
using System.Collections.Generic;
using checkpoint8.Models;
using checkpoint8.Services;
using Microsoft.AspNetCore.Mvc;

namespace checkpoint8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly KeepsService _kService;
        private readonly VaultsService _vService;
        private readonly AccountService _aService;
        public ProfilesController(KeepsService kService, VaultsService vService, AccountService aService)
        {

            _kService = kService;
            _vService = vService;
            _aService = aService;
        }

        [HttpGet("{id}")]
        public ActionResult<Profile> Get(string id)
        {
            try
            {
                Profile profile = _aService.GetProfile(id);
                return Ok(profile);
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
                return Ok(keeps);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // TODO GetVaultsByProfile
        // Format similar to below
        [HttpGet("{id}/vaults")]
        public ActionResult<List<Vault>> GetVaultsByProfile(string id)
        {
            try
            {
                // Account userInfo = 
                List<Vault> vaults = _vService.GetMyVaults(id);
                return Ok(vaults);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
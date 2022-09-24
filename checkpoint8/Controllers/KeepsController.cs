using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using checkpoint8.Models;
using checkpoint8.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace checkpoint8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class KeepsController : ControllerBase
    {
        private readonly KeepsService _kService;

        public KeepsController(KeepsService kService)
        {
            _kService = kService;
        }

        // [HttpGet]
        // public async Task<ActionResult<List<Keep>>> GetAll()
        // {
        //     try
        //     {
        //         Account user = await HttpContext.GetUserInfoAsync<Account>();
        //         List<Keep> keeps = _kService.GetAll(user?.Id);
        //         return Ok(keeps);
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }
        [HttpGet]
        public async Task<ActionResult<List<Keep>>> GetAll()
        {
            try
            {
                Account user = await HttpContext.GetUserInfoAsync<Account>();
                List<Keep> keeps = _kService.GetAll();
                return Ok(keeps);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Keep>> GetById(int id)
        {
            try
            {
                Account user = await HttpContext.GetUserInfoAsync<Account>();
                Keep keep = _kService.GetById(id, user?.Id);
                return Ok(keep);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Keep>> Create([FromBody] Keep keepData)
        {
            try
            {
                Account user = await HttpContext.GetUserInfoAsync<Account>();
                keepData.CreatorId = user.Id;
                Keep keep = _kService.Create(keepData, user);
                keep.Creator = user;
                return Ok(keep);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Keep>> Update(int id, [FromBody] Keep keepData)
        {
            try
            {
                Account user = await HttpContext.GetUserInfoAsync<Account>();
                keepData.Id = id;
                Keep keep = _kService.Update(keepData, user);
                return Ok(keep);
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
                string message = _kService.Delete(id, user);
                return Ok(message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
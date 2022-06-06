using DAWPROIECTR.Interfaces;
using DAWPROIECTR.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAWPROIECTR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientManager _clientManager;

        public ClientController(IClientManager clientManager)
        {
            _clientManager = clientManager;
        }
        // autorizatii

        //    [Authorize("Admin")]
        [HttpGet("get-all-clienti")]
        public async Task<IActionResult> GetClienti()
        {
            try
            {
                var list = await _clientManager.GetClienti();
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // [Authorize("Admin")]
        [HttpGet("get-clienti-by-id/{id}")]
        public async Task<IActionResult> GetClientiById(int id)
        {
            try
            {
                var client = await _clientManager.GetClientById(id);
                return Ok(client);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //[Authorize("Admin")]
        [HttpPost("insert-clienti")]
        public async Task<IActionResult> InsertClient(ClientModel clientModel)
        {
            try
            {
                var client = await _clientManager.InsertClient(clientModel);
                return Ok(client);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // [Authorize("Admin")]
        [HttpPut("update-clienti")]
        public async Task<IActionResult> UpdateClient(ClientModel clientModel)
        {
            try
            {
                var client = await _clientManager.UpdateClient(clientModel);
                return Ok(client);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //[Authorize("Admin")]
        [HttpDelete("delete-clienti")]
        public async Task<IActionResult> DeleteClient(ClientModel clientModel)
        {
            try
            {
                var client = await _clientManager.DeleteClient(clientModel);
                return Ok(client);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }




    }
}
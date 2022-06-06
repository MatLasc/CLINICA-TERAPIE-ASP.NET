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
    public class TerapeutController : ControllerBase
    {
        private readonly ITerapeutManager _terapeutManager;

        public TerapeutController(ITerapeutManager terapeutManager)
        {
            _terapeutManager = terapeutManager;
        }
        // autorizatii

        //   [AllowAnonymous]
        [HttpGet("get-all-terapeuti")]
        public async Task<IActionResult> GetTerapeuti()
        {
            try
            {
                var list = await _terapeutManager.GetTerapeuti();
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // [AllowAnonymous]
        [HttpGet("get-terapeuti-by-id/{id}")]
        public async Task<IActionResult> GetTerapeutById(int id)
        {
            try
            {
                var terapeut = await _terapeutManager.GetTerapeutById(id);
                return Ok(terapeut);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // [Authorize("Admin")]
        [HttpPost("insert-terapeut")]
        public async Task<IActionResult> InsertTerapeut(TerapeutModel terapeutModel)
        {
            try
            {
                var terapeut = await _terapeutManager.InsertTerapeut(terapeutModel);
                return Ok(terapeut);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // [Authorize("Admin")]
        [HttpPut("update-terapeut")]
        public async Task<IActionResult> UpdateTerapeut(TerapeutModel terapeutModel)
        {
            try
            {
                var terapeut = await _terapeutManager.UpdateTerapeut(terapeutModel);
                return Ok(terapeut);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //  [Authorize("Admin")]
        [HttpDelete("delete-terapeut")]
        public async Task<IActionResult> DeleteTerapeut(TerapeutModel terapeutModel)
        {
            try
            {
                var terapeut = await _terapeutManager.DeleteTerapeut(terapeutModel);
                return Ok(terapeut);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }




    }
}

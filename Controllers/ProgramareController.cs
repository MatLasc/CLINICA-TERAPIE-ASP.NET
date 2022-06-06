using DAWPROIECTR.Models;
using DAWPROIECTR.Interfaces;
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
    public class ProgramareController : ControllerBase
    {
        private readonly IProgramareManager _programareManager;

        public ProgramareController(IProgramareManager programareManager)
        {
            _programareManager = programareManager;
        }
        // autorizatii

        //[Authorize("Admin")]
        [HttpGet("get-all-programari")]
        public async Task<IActionResult> GetProgramari()
        {
            try
            {
                var list = await _programareManager.GetProgramari();
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Authorize[(Roles = "Admin, Client")]
        [HttpGet("get-programari-by-id/{id}")]
        public async Task<IActionResult> GetProgramariById(int id)
        {
            try
            {
                var programare = await _programareManager.GetProgramareById(id);
                return Ok(programare);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //[Authorize(Roles = "Admin, Client")]
        [HttpGet("get-programari-by-ClientId/{clientId}")]
        public async Task<IActionResult> GetProgramaribyClientId(int id)
        {
            try
            {
                var programare = await _programareManager.GetProgramariByClientId(id);
                return Ok(programare);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // [Authorize(Roles = "Admin, Client")]
        [HttpGet("get-programari-by-TerapeutId/{terapeutId}")]
        public async Task<IActionResult> GetProgramaribyTerapeutId(int id)
        {
            try
            {
                var programare = await _programareManager.GetProgramariByTerapeutId(id);
                return Ok(programare);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // [Authorize("Admin")]
        [HttpPost("insert-programare")]
        public async Task<IActionResult> InsertProgramare(ProgramareModel programareModel)
        {
            try
            {
                var programare = await _programareManager.InsertProgramare(programareModel);
                return Ok(programare);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // [Authorize("Admin")]
        [HttpPut("update-programare")]
        public async Task<IActionResult> UpdateProgramare(ProgramareModel programareModel)
        {
            try
            {
                var programare = await _programareManager.UpdateProgramare(programareModel);
                return Ok(programare);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //  [Authorize("Admin")]
        [HttpDelete("delete-programare")]
        public async Task<IActionResult> DeleteProgramare(ProgramareModel programareModel)
        {
            try
            {
                var programare = await _programareManager.DeleteProgramare(programareModel);
                return Ok(programare);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }




    }
}

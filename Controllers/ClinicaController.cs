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
    public class ClinicaController : ControllerBase
    {
        private readonly IClinicaManager _clinicaManager;

        public ClinicaController(IClinicaManager clinicaManager)
        {
            _clinicaManager = clinicaManager;
        }

        // autorizatii

        //   [AllowAnonymous]
        [HttpGet("get-all-clinici")]
        public async Task<IActionResult> GetClinici()
        {
            try
            {
                var list = await _clinicaManager.GetClinici();
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //[Authorize("Client")]
        [HttpGet("get-clinici-by-id/{id}")]
        public async Task<IActionResult> GetCliniciById(int id)
        {
            try
            {
                var clin = await _clinicaManager.GetClinicaById(id);
                return Ok(clin);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // [Authorize("Admin")]
        [HttpPost("insert-clinica")]
        public async Task<IActionResult> InsertClinica(ClinicaModel clinicaModel)
        {//try
         //  {
            var clin = await _clinicaManager.InsertClinica(clinicaModel);
            return Ok(clin);
            // }
            //catch (Exception e) 
            //  { 
            //   return BadRequest(e.Message); 
            // } 
        }

        //  [Authorize("Admin")]
        [HttpPut("update-clinica")]
        public async Task<IActionResult> UpdateClinica(ClinicaModel clinicaModel)
        {
            try
            {
                var clin = await _clinicaManager.UpdateClinica(clinicaModel);
                return Ok(clin);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //  [Authorize("Admin")]
        [HttpDelete("delete-clinica")]
        public async Task<IActionResult> DeleteClinica(ClinicaModel clinicaModel)
        {
            try
            {
                var clin = await _clinicaManager.DeleteClinica(clinicaModel);
                return Ok(clin);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }




    }
}

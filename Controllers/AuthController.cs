using DAWPROIECTR.Interfaces;
using DAWPROIECTR.Models;
using DAWPROIECTR.Managers;
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
    public class AuthController : ControllerBase
    {
        private readonly IAuthManager _authManager;
        private readonly IClientManager _clientManager;

        public AuthController(IAuthManager authManager, IClientManager clientManager)
        {
            _authManager = authManager;
            _clientManager = clientManager;

        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            var result = await _authManager.Register(registerModel);
            return result ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Register-Client")]
        public async Task<IActionResult> RegisterClient([FromBody] RegisterClientModel registerClientModel)
        {
            var result = await _authManager.RegisterClient(registerClientModel.registerModel);
            if (result == null)
            {
                return BadRequest();
            }

            registerClientModel.clientModel.UserId = result.Value;

            var client = await _clientManager.InsertClient(registerClientModel.clientModel);
            return Ok(client);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var result = await _authManager.Login(loginModel);
            return result.Success ? Ok(result) : BadRequest("Failed to login");
        }

        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshModel refreshModel)
        {
            var result = await _authManager.Refresh(refreshModel);
            return !result.Contains("Bad") ? Ok(result) : BadRequest("Failed to refresh");
        }
    }
}

using Azure.Core;
using Case_Marking_Web_Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace TowerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService) 
        {
            _authenticationService = authenticationService;
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var remoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();

            // Get the port number of the client from the HttpContext
            int? port = HttpContext.Connection.RemotePort;

            return await _authenticationService.Login(model);


        }

        [HttpGet]
        [Route("test")]
        public async Task<IActionResult> Test()
        {
            var remoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();

            // Get the port number of the client from the HttpContext
            int? port = HttpContext.Connection.RemotePort;

            return Ok(new { resp = "Server is live" });

        }
    }
}

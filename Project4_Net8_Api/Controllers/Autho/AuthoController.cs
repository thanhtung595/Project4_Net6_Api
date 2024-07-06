using Lib_Models.Model_Post;
using Lib_Models.Model_Table;
using Lib_Models.Status;
using Lib_Services.Authoz;
using Lib_Services.Jwt;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project4_Net8_Api.Controllers.Autho
{
    [Route("api/authoz")]
    [ApiController]
    public class AuthoController : ControllerBase
    {
        private readonly IAuthoz _iAuthoz;
        private readonly ICustomCookieService _customCookieService;
        public AuthoController(IAuthoz iAuthoz, ICustomCookieService customCookieService)
        {
            _iAuthoz = iAuthoz;
            _customCookieService = customCookieService;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel login)
        {
            StatusApplication status = await _iAuthoz.Login(login);
            if (status.isBool)
            {
                _customCookieService.SetCookieAllTime("localhost", "accesstoken", status.message!);
                return Ok(status.obj);
            }
            return BadRequest(status);
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel register)
        {
            StatusApplication status = await _iAuthoz.Register(register);
            if (status.isBool)
            {
                return Ok(status);
            }
            return BadRequest(status);
        }
    }
}

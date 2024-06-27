using Lib_Models.Model_Post;
using Lib_Models.Model_Table;
using Lib_Services.Authoz;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project4_Net8_Api.Controllers.Autho
{
    [Route("api/authoz")]
    [ApiController]
    public class AuthoController : ControllerBase
    {
        private readonly IAuthoz _iAuthoz;
        public AuthoController(IAuthoz iAuthoz)
        {
            _iAuthoz = iAuthoz;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel login)
        {
            LoginModelTable status = await _iAuthoz.Login(login);
            if (status.isBool)
            {
                return Ok(status);
            }
            return BadRequest(status);
        }
    }
}

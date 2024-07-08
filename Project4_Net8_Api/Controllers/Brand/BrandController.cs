using Lib_Models.Status;
using Lib_Services.Brand;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project4_Net8_Api.Controllers.Brand
{
    [Route("api/brand")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _brandService.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Add(string name)
        {
            StatusApplication status = await _brandService.Add(name);
            if (!status.isBool)
            {
                return BadRequest(status.message);
            }
            return StatusCode(201, status.message);
        }
    }
}

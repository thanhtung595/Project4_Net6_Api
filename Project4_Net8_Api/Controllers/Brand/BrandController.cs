using Lib_Models.Model_Entities;
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

        [HttpPut]
        public async Task<IActionResult> Edit(BrandEntity brand)
        {
            StatusApplication status = await _brandService.Update(brand);
            if (status.isBool)
            {
                return StatusCode(204);
            }
            return StatusCode(400, status);
        }
    }
}

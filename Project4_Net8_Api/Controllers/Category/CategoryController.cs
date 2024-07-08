using Lib_Models.Model_Post;
using Lib_Models.Status;
using Lib_Services.Category;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project4_Net8_Api.Controllers.Category
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoryService.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryModel category)
        {
            StatusApplication status = await _categoryService.Add(category);
            if (!status.isBool)
            {
                return BadRequest(status.message);
            }
            return StatusCode(201);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCate cate)
        {
            StatusApplication status = await _categoryService.Update(cate.id, cate.name!, cate.isActive);
            if (!status.isBool)
            {
                return StatusCode(400, status);
            }
            return StatusCode(204);
        }

        public class UpdateCate
        {
            public int id { get; set; }
            public string? name { get; set; }
            public bool isActive { get; set; }
        }
    }
}

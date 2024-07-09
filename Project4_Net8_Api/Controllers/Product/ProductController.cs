using Azure.Core;
using Lib_DatabaseEntity;
using Lib_Models.Model_Post;
using Lib_Models.Model_Table;
using Lib_Models.Status;
using Lib_Services.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project4_Net8_Api.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project4_Net8_Api.Controllers.Product
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await  _productService.GetAll());
        }

        [Authorize(Policy = IdentityData.AdminPolicyName)]
        [HttpPost]
        public async Task<IActionResult> Add(ProductPost productPost)
        {
            StatusApplication status = await _productService.Add(productPost);
            if (status.isBool)
            {
                FileAddRequest addFile = new FileAddRequest
                {
                    file = productPost.img,
                    newFileName = status.message,
                    path = "wwwroot/img/product"
                };
                FileSrc.AddFileInFolder_FileSrc(addFile);
                return StatusCode(201);
            }
            return BadRequest(status.message);
        }

        [Authorize(Policy = IdentityData.AdminPolicyName)]
        [HttpPut]
        public async Task<IActionResult> Update(ProductMode_Update product)
        {
            StatusApplication status = await _productService.Update(product);
            if (status.isBool)
            {
                if (product.img != null)
                {
                    FileSrc.DeleteFile(status.message!, "wwwroot/img/product");
                    FileAddRequest addFile = new FileAddRequest
                    {
                        file = product.img,
                        newFileName = product.name,
                        path = "wwwroot/img/product"
                    };
                    FileSrc.AddFileInFolder_FileSrc(addFile);
                }
                return StatusCode(204);
            }
            return StatusCode(400, status);
        }
    }
}

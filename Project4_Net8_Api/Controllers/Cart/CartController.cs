using Lib_Models.Model_Post;
using Lib_Services.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project4_Net8_Api.Controllers.Cart
{
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _cartService.GetAll());
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(CartAdd_Post cart)
        {
            await _cartService.Add(cart);
            return StatusCode(201);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update(CartModel_Update cart)
        {
            await _cartService.Update(cart);
            return StatusCode(201);
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Update(int id)
        {
            await _cartService.Delete(id);
            return StatusCode(201);
        }
    }
}

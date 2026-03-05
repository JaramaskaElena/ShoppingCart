using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Application.Dtos;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.ShoppingCart.Domain.Entities;

namespace ShoppingCart.Presentation.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _service;

        public CartController(ICartService service)
        {
            _service = service;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<Cart?>> GetCart(int userId)
        {
            var cart = await _service.GetCartAsync(userId);
            if (cart == null) return NotFound("Cart not found");
            return Ok(cart);
        }

        [HttpPost("{userId}/add")]
        public async Task<IActionResult> AddItem(int userId, [FromBody] AddItemRequest request)
        {
            await _service.AddItemAsync(userId, request.ProductId, request.Quantity);
            return Ok();
        }

        [HttpPost("{userId}/remove/{productId}")]
        public async Task<IActionResult> RemoveItem(int userId, int productId)
        {
            await _service.RemoveItemAsync(userId, productId);
            return Ok();
        }

        [HttpPost("{userId}/clear")]
        public async Task<IActionResult> ClearCart(int userId)
        {
            await _service.ClearCartAsync(userId);
            return Ok();
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteCart(int userId)
        {
            await _service.DeleteCartAsync(userId);
            return Ok();
        }
    }
}
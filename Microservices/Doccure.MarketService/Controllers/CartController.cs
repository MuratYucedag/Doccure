using Doccure.MarketService.Dtos.CartDtos;
using Doccure.MarketService.Services.CartServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.MarketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddItemToCart(int patientId, CartItemDto item)
        {
            await _cartService.AddItemToCartAsync(patientId, item);
            return Ok("Ürün sepete eklendi");
        }

        [HttpGet("{patientId}")]
        public async Task<IActionResult> GetCart(int patientId)
        {
            var values = await _cartService.GetCartAsync(patientId);
            return Ok(values);
        }

        [HttpDelete("{patientId}/{productId}")]
        public async Task<IActionResult> RemoveItem(int patientId, int productId)
        {
            await _cartService.RemoveItemAsync(patientId, productId);
            return Ok("Ürün sepetten kaldırıldı");
        }

        [HttpDelete("clear/{patientId}")]
        public async Task<IActionResult> ClearCart(int patientId)
        {
            await _cartService.ClearCartAsync(patientId);
            return Ok("Sepet temizlendi");
        }
    }
}

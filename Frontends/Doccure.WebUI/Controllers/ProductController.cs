using Doccure.WebUI.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> ProductList()
        {
            var values = await _productService.GetAllProductsAsync();
            return View(values);
        }
    }
}

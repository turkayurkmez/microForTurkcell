using Catalog.Application;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IBookService productService;

        public ProductsController(IBookService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(productService.GetBooks());
        }
    }
}

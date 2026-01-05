using Microsoft.AspNetCore.Mvc;

namespace ProductCatalog.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = new[]
            {
                new { Id = 1, Name = "Laptop", Price = 75000 },
                new { Id = 2, Name = "Mobile", Price = 25000 }
            };

            return Ok(products);
        }
    }
}

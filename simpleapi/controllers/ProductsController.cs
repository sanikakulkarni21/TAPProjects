using Microsoft.AspNetCore.Mvc;
using SimpleApi.Models;
using SimpleApi.Services;

namespace SimpleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductsController(ProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            var created = _service.Add(product);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }
    }
}
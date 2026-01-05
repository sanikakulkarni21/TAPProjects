using Microsoft.AspNetCore.Mvc;

namespace ShoppingCart.Api.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : ControllerBase
    {
        [HttpPost("add")]
        public IActionResult AddToCart(object item)
        {
            return Ok("Item added to cart");
        }
    }
}


/*{
  "Id": 1,
  "Name": "Laptop",
  "price": 75000
}
*/
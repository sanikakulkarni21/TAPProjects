using Microsoft.AspNetCore.Mvc;

namespace OrderProcessing.Api.Controllers
{
    [ApiController]
    [Route("/api/orders")]
    public class OrdersController : ControllerBase
    {
        [HttpPost]
        public IActionResult PlaceOrder(object order)
        {
            return Ok("Order placed successfully");
        }
    }
}

/*{
  "productId": 1,
  "productName": "Laptop",
  "price": 75000,
  "quantity": 1
}
*/
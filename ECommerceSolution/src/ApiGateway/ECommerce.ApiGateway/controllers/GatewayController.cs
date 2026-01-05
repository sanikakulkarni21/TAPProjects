using Microsoft.AspNetCore.Mvc;

namespace ECommerce.ApiGateway.controllers;

[ApiController]
[Route("api/Gateway")]
public class GatewayController : ControllerBase
{
    [HttpGet]
    public IActionResult Health()
    {
        return Ok("Gateway working fine");
    }
}

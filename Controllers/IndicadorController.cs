using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class IndicadoresController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { mensaje = "API funcionando correctamente" });
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaIndicadoresAPI.Data;
using SistemaIndicadoresAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class PruebaController : ControllerBase
{
    private readonly SistemaIndicadoresContext _context;

    public PruebaController(SistemaIndicadoresContext context)
    {
        _context = context;
    }

    [HttpGet("verificar-conexion")]
    public async Task<IActionResult> VerificarConexion()
    {
        try
        {
            var existeDatos = await _context.Indicador.AnyAsync();
            return Ok(new { conexionExitosa = true, hayDatos = existeDatos });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { conexionExitosa = false, error = ex.Message });
        }
    }
}

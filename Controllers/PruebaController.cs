using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaIndicadoresAPI.Data;
using System;
using System.Threading.Tasks;

namespace SistemaIndicadoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaController : ControllerBase
    {
        private readonly SistemaIndicadoresContext _context;

        public PruebaController(SistemaIndicadoresContext context)
        {
            _context = context;
        }

        // GET: api/Prueba/verificar-conexion
        [HttpGet("verificar-conexion")]
        public async Task<IActionResult> VerificarConexion()
        {
            try
            {
                bool hayDatos = await _context.Indicador.AnyAsync();
                return Ok(new 
                { 
                    conexionExitosa = true, 
                    hayDatos 
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new 
                { 
                    conexionExitosa = false, 
                    error = ex.Message 
                });
            }
        }
    }
}

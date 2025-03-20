using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaIndicadoresAPI;
using SistemaIndicadoresAPI.Data;
using SistemaIndicadoresAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaIndicadoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoIndicadorController : ControllerBase
    {
        private readonly SistemaIndicadoresContext _context;

        public TipoIndicadorController(SistemaIndicadoresContext context)
        {
            _context = context;
        }

        // GET: api/TipoIndicador
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoIndicador>>> GetTipoIndicadores()
        {
            return await _context.TipoIndicador.ToListAsync();
        }

        // GET: api/TipoIndicador/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoIndicador>> GetTipoIndicador(int id)
        {
            var tipoIndicador = await _context.TipoIndicador.FindAsync(id);

            if (tipoIndicador == null)
            {
                return NotFound();
            }

            return tipoIndicador;
        }

        // POST: api/TipoIndicador
        [HttpPost]
        public async Task<ActionResult<TipoIndicador>> PostTipoIndicador(TipoIndicador tipoIndicador)
        {
            _context.TipoIndicador.Add(tipoIndicador);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTipoIndicador), new { id = tipoIndicador.Id }, tipoIndicador);
        }

        // PUT: api/TipoIndicador/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoIndicador(int id, TipoIndicador tipoIndicador)
        {
            if (id != tipoIndicador.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoIndicador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.TipoIndicador.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
public async Task<IActionResult> DeleteTipoIndicador(int id)
{
    var tipoIndicador = await _context.TipoIndicadores.FindAsync(id);
    if (tipoIndicador == null)
        return NotFound();

    try
    {
        _context.TipoIndicadores.Remove(tipoIndicador);
        await _context.SaveChangesAsync();
        return NoContent();
    }
    catch (Exception ex)
    {
        // Aquí puedes registrar el error para depuración
        return StatusCode(500, new { error = ex.Message });
    }
}

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaIndicadoresAPI.Data;
using SistemaIndicadoresAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaIndicadoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrecuenciaController : ControllerBase
    {
        private readonly SistemaIndicadoresContext _context;

        public FrecuenciaController(SistemaIndicadoresContext context)
        {
            _context = context;
        }

        // GET: api/Frecuencia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Frecuencia>>> GetFrecuencias()
        {
            return await _context.Frecuencia.ToListAsync();
        }

        // GET: api/Frecuencia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Frecuencia>> GetFrecuencia(int id)
        {
            var frecuencia = await _context.Frecuencia.FindAsync(id);
            if (frecuencia == null)
            {
                return NotFound();
            }
            return frecuencia;
        }

        // POST: api/Frecuencia
        [HttpPost]
        public async Task<ActionResult<Frecuencia>> PostFrecuencia(Frecuencia frecuencia)
        {
            if (frecuencia == null || string.IsNullOrEmpty(frecuencia.Nombre))
            {
                return BadRequest("El nombre de la frecuencia es requerido.");
            }

            _context.Frecuencia.Add(frecuencia);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFrecuencia), new { id = frecuencia.Id }, frecuencia);
        }

        // PUT: api/Frecuencia/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFrecuencia(int id, Frecuencia frecuencia)
        {
            if (id != frecuencia.Id || string.IsNullOrEmpty(frecuencia.Nombre))
            {
                return BadRequest("Datos inválidos.");
            }

            _context.Entry(frecuencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Frecuencia.Any(e => e.Id == id))
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

        // DELETE: api/Frecuencia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFrecuencia(int id)
        {
            var frecuencia = await _context.Frecuencia.FindAsync(id);
            if (frecuencia == null)
            {
                return NotFound();
            }

            _context.Frecuencia.Remove(frecuencia);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
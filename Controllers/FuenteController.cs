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
    public class FuenteController : ControllerBase
    {
        private readonly SistemaIndicadoresContext _context;

        public FuenteController(SistemaIndicadoresContext context)
        {
            _context = context;
        }

        // GET: api/Fuente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fuente>>> GetFuentes()
        {
            return await _context.Fuente.ToListAsync();
        }

        // GET: api/Fuente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fuente>> GetFuente(int id)
        {
            var fuente = await _context.Fuente.FindAsync(id);

            if (fuente == null)
            {
                return NotFound();
            }

            return fuente;
        }

        // POST: api/Fuente
        [HttpPost]
        public async Task<ActionResult<Fuente>> PostFuente(Fuente fuente)
        {
            _context.Fuente.Add(fuente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFuente), new { id = fuente.Id }, fuente);
        }

        // PUT: api/Fuente/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuente(int id, Fuente fuente)
        {
            if (id != fuente.Id)
            {
                return BadRequest();
            }

            _context.Entry(fuente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Fuente.Any(e => e.Id == id))
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

        // DELETE: api/Fuente/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuente(int id)
        {
            var fuente = await _context.Fuente.FindAsync(id);
            if (fuente == null)
            {
                return NotFound();
            }

            _context.Fuente.Remove(fuente);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

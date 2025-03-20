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
    public class SentidoController : ControllerBase
    {
        private readonly SistemaIndicadoresContext _context;

        public SentidoController(SistemaIndicadoresContext context)
        {
            _context = context;
        }

        // GET: api/Sentido
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sentido>>> GetSentidos()
        {
            return await _context.Sentido.ToListAsync();
        }

        // GET: api/Sentido/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sentido>> GetSentido(int id)
        {
            var sentido = await _context.Sentido.FindAsync(id);

            if (sentido == null)
            {
                return NotFound();
            }

            return sentido;
        }

        // POST: api/Sentido
        [HttpPost]
        public async Task<ActionResult<Sentido>> PostSentido(Sentido sentido)
        {
            // Verifica si el Sentido ya existe
            var existe = await _context.Sentido.AnyAsync(s => s.Nombre == sentido.Nombre);
            if (existe)
            {
                return BadRequest("El sentido ya existe.");
            }

            _context.Sentido.Add(sentido);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSentido), new { id = sentido.Id }, sentido);
        }

        // PUT: api/Sentido/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSentido(int id, Sentido sentido)
        {
            if (id != sentido.Id)
            {
                return BadRequest();
            }

            _context.Entry(sentido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Sentido.AnyAsync(e => e.Id == id))
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

        // DELETE: api/Sentido/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSentido(int id)
        {
            var sentido = await _context.Sentido.FindAsync(id);
            if (sentido == null)
            {
                return NotFound();
            }

            _context.Sentido.Remove(sentido);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

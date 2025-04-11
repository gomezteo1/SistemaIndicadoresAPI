using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaIndicadoresAPI.Data;
using SistemaIndicadoresAPI.Models; // Cambiá esto por tu namespace real
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaIndicadoresAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LiteralController : ControllerBase
    {
        private readonly SistemaIndicadoresContext _context;

        public LiteralController(SistemaIndicadoresContext context)
        {
            _context = context;
        }

        // GET: api/Literal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Literal>>> GetLiterales()
        {
            return await _context.Literal
                                 .Include(l => l.Articulo)
                                 .ToListAsync();
        }

        // GET: api/Literal/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Literal>> GetLiteral(string id)
        {
            var literal = await _context.Literal
                                        .Include(l => l.Articulo)
                                        .FirstOrDefaultAsync(l => l.Id == id);

            if (literal == null)
                return NotFound();

            return literal;
        }

        // POST: api/Literal
        [HttpPost]
        public async Task<ActionResult<Literal>> PostLiteral(Literal literal)
        {
            _context.Literal.Add(literal);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetLiteral), new { id = literal.Id }, literal);
        }

        // PUT: api/Literal/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLiteral(string id, Literal literal)
        {
            if (id != literal.Id)
                return BadRequest("El ID en la URL no coincide con el del objeto.");

            _context.Entry(literal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LiteralExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Literal/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLiteral(string id)
        {
            var literal = await _context.Literal.FindAsync(id);
            if (literal == null)
                return NotFound();

            _context.Literal.Remove(literal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LiteralExists(string id)
        {
            return _context.Literal.Any(e => e.Id == id);
        }
    }
}

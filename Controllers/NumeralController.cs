using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaIndicadoresAPI.Data;
using SistemaIndicadoresAPI.Models; // Cambiá el namespace si usás otro
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaIndicadoresAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NumeralController : ControllerBase
    {
        private readonly SistemaIndicadoresContext _context;

        public NumeralController(SistemaIndicadoresContext context)
        {
            _context = context;
        }

        // GET: api/Numeral
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Numeral>>> GetNumeral()
        {
            return await _context.Numeral
                                 .Include(n => n.Literal)
                                 .ToListAsync();
        }

        // GET: api/Numeral/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Numeral>> GetNumeral(string id)
        {
            var numeral = await _context.Numeral
                                        .Include(n => n.Literal)
                                        .FirstOrDefaultAsync(n => n.Id == id);

            if (numeral == null)
                return NotFound();

            return numeral;
        }

        // POST: api/Numeral
        [HttpPost]
        public async Task<ActionResult<Numeral>> PostNumeral(Numeral numeral)
        {
            _context.Numeral.Add(numeral);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNumeral), new { id = numeral.Id }, numeral);
        }

        // PUT: api/Numeral/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNumeral(string id, Numeral numeral)
        {
            if (id != numeral.Id)
                return BadRequest("El ID no coincide con el objeto enviado.");

            _context.Entry(numeral).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NumeralExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Numeral/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNumeral(string id)
        {
            var numeral = await _context.Numeral.FindAsync(id);
            if (numeral == null)
                return NotFound();

            _context.Numeral.Remove(numeral);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NumeralExists(string id)
        {
            return _context.Numeral.Any(n => n.Id == id);
        }
    }
}

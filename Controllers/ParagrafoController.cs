using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaIndicadoresAPI.Data;

namespace SistemaIndicadoresAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParagrafoController : ControllerBase
    {
        private readonly SistemaIndicadoresContext _context;

        public ParagrafoController(SistemaIndicadoresContext context)
        {
            _context = context;
        }

        // GET: api/Paragrafo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paragrafo>>> GetParagrafo()
        {
            return await _context.Paragrafo
                                 .Include(p => p.Articulo)
                                 .ToListAsync();
        }

        // GET: api/Paragrafo/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Paragrafo>> GetParagrafo(string id)
        {
            var paragrafo = await _context.Paragrafo
                                          .Include(p => p.Articulo)
                                          .FirstOrDefaultAsync(p => p.Id == id);

            if (paragrafo == null)
                return NotFound();

            return paragrafo;
        }

        // POST: api/Paragrafo
        [HttpPost]
        public async Task<ActionResult<Paragrafo>> PostParagrafo(Paragrafo paragrafo)
        {
            _context.Paragrafo.Add(paragrafo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetParagrafo), new { id = paragrafo.Id }, paragrafo);
        }

        // PUT: api/Paragrafo/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParagrafo(string id, Paragrafo paragrafo)
        {
            if (id != paragrafo.Id)
                return BadRequest("El ID no coincide.");

            _context.Entry(paragrafo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParagrafoExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Paragrafo/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParagrafo(string id)
        {
            var paragrafo = await _context.Paragrafo.FindAsync(id);
            if (paragrafo == null)
                return NotFound();

            _context.Paragrafo.Remove(paragrafo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParagrafoExists(string id)
        {
            return _context.Paragrafo.Any(p => p.Id == id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaIndicadoresAPI.Data;
using SistemaIndicadoresAPI.Models;

namespace SistemaIndicadoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VariablePorIndicadorController : ControllerBase
    {
        private readonly SistemaIndicadoresContext _context;

        public VariablePorIndicadorController(SistemaIndicadoresContext context)
        {
            _context = context;
        }

        // GET: api/VariablePorIndicador
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VariablePorIndicador>>> GetAll()
        {
            return await _context.VariablePorIndicador.ToListAsync();
        }

        // GET: api/VariablePorIndicador/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VariablePorIndicador>> GetById(int id)
        {
            var item = await _context.VariablePorIndicador.FindAsync(id);

            if (item == null)
                return NotFound();

            return item;
        }

        // POST: api/VariablePorIndicador
        [HttpPost]
        public async Task<ActionResult<VariablePorIndicador>> Post(VariablePorIndicador entity)
        {
            _context.VariablePorIndicador.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
        }

        // PUT: api/VariablePorIndicador/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, VariablePorIndicador entity)
        {
            if (id != entity.Id)
                return BadRequest();

            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.VariablePorIndicador.Any(e => e.Id == id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        // DELETE: api/VariablePorIndicador/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.VariablePorIndicador.FindAsync(id);
            if (entity == null)
                return NotFound();

            _context.VariablePorIndicador.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

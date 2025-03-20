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
    public class TipoActorController : ControllerBase
    {
        private readonly SistemaIndicadoresContext _context;

        public TipoActorController(SistemaIndicadoresContext context)
        {
            _context = context;
        }

        // GET: api/TipoActor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoActor>>> GetTipoActores()
        {
            return await _context.TipoActor.ToListAsync();
        }

        // GET: api/TipoActor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoActor>> GetTipoActor(int id)
        {
            var tipoActor = await _context.TipoActor.FindAsync(id);

            if (tipoActor == null)
            {
                return NotFound();
            }

            return tipoActor;
        }

        // POST: api/TipoActor
        [HttpPost]
        public async Task<ActionResult<TipoActor>> PostTipoActor(TipoActor tipoActor)
        {
            _context.TipoActor.Add(tipoActor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTipoActor), new { id = tipoActor.Id }, tipoActor);
        }

        // PUT: api/TipoActor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoActor(int id, TipoActor tipoActor)
        {
            if (id != tipoActor.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoActor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.TipoActor.Any(e => e.Id == id))
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

        // DELETE: api/TipoActor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoActor(int id)
        {
            var tipoActor = await _context.TipoActor.FindAsync(id);
            if (tipoActor == null)
            {
                return NotFound();
            }

            _context.TipoActor.Remove(tipoActor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

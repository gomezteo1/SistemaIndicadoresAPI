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
    public class SubseccionController : ControllerBase
    {
        private readonly SistemaIndicadoresContext _context;

        public SubseccionController(SistemaIndicadoresContext context)
        {
            _context = context;
        }
        
        // GET: api/Subseccion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subseccion>>> GetSubsecciones()
        {
            return await _context.Subseccion.ToListAsync();
        }

        // GET: api/Subseccion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subseccion>> GetSubseccion(string id)
        {
            var subseccion = await _context.Subseccion.FindAsync(id);

            if (subseccion == null)
            {
                return NotFound();
            }

            return subseccion;
        }

        // POST: api/Subseccion
        [HttpPost]
        public async Task<ActionResult<Subseccion>> PostSubseccion(Subseccion subseccion)
        {
            _context.Subseccion.Add(subseccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSubseccion), new { id = subseccion.Id }, subseccion);
        }

        // PUT: api/Subseccion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubseccion(string id, Subseccion subseccion)
        {
            if (id != subseccion.Id)
            {
                return BadRequest();
            }

            _context.Entry(subseccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Subseccion.Any(e => e.Id == id))
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
        public async Task<IActionResult> DeleteSubseccion(string id)
        {
            var subseccion = await _context.Subseccion.FindAsync(id);
            if (subseccion == null) return NotFound();

            _context.Subseccion.Remove(subseccion);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}

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
    public class SeccionController : ControllerBase
    {
        private readonly SistemaIndicadoresContext _context;

        public SeccionController(SistemaIndicadoresContext context)
        {
            _context = context;
        }
        
        // GET: api/Seccion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seccion>>> GetSecciones()
        {
            return await _context.Seccion.ToListAsync();
        }

        // GET: api/seccion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Seccion>> GetSeccion(string id)
        {
            var seccion = await _context.Seccion.FindAsync(id);

            if (seccion == null)
            {
                return NotFound();
            }

            return seccion;
        }

        // POST: api/Subseccion
        [HttpPost]
        public async Task<ActionResult<Seccion>> PostSeccion(Seccion seccion)
        {
            _context.Seccion.Add(seccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSeccion), new { id = seccion.Id }, seccion);
        }

        // PUT: api/seccion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeccion(string id, Seccion seccion)
        {
            if (id != seccion.Id)
            {
                return BadRequest();
            }

            _context.Entry(seccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Seccion.Any(e => e.Id == id))
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
        public async Task<IActionResult> DeleteSeccion(string id)
        {
            var seccion = await _context.Seccion.FindAsync(id);
            if (seccion == null) return NotFound();

            _context.Seccion.Remove(seccion);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}

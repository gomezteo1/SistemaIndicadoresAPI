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
    public class RepresenVisualController : ControllerBase
    {
        private readonly SistemaIndicadoresContext _context;

        public RepresenVisualController(SistemaIndicadoresContext context)
        {
            _context = context;
        }

        // GET: api/RepresenVisual
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepresenVisual>>> GetRepresenVisuales()
        {
            return await _context.RepresenVisual.ToListAsync();
        }

        // GET: api/RepresenVisual/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepresenVisual>> GetRepresenVisual(int id)
        {
            var represenvisual = await _context.RepresenVisual.FindAsync(id);

            if (represenvisual == null)
            {
                return NotFound();
            }

            return represenvisual;
        }

        // POST: api/RepresenVisual
        [HttpPost]
        public async Task<ActionResult<RepresenVisual>> PostRepresenVisual(RepresenVisual represenvisual)
        {
            _context.RepresenVisual.Add(represenvisual);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRepresenVisual), new { id = represenvisual.Id }, represenvisual);
        }

        // PUT: api/RepresenVisual/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepresenVisual(int id, RepresenVisual represenvisual)
        {
            if (id != represenvisual.Id)
            {
                return BadRequest();
            }

            _context.Entry(represenvisual).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.RepresenVisual.Any(e => e.Id == id))
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

        // DELETE: api/RepresenVisual/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepresenVisual(int id)
        {
            var represenvisual = await _context.RepresenVisual.FindAsync(id);
            if (represenvisual == null)
            {
                return NotFound();
            }

            _context.RepresenVisual.Remove(represenvisual);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

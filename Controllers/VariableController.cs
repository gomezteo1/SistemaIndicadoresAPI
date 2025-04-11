using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaIndicadoresAPI.Data;
using SistemaIndicadoresAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaIndicadoresAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VariableController : ControllerBase
    {
        private readonly SistemaIndicadoresContext _context;

        public VariableController(SistemaIndicadoresContext context)
        {
            _context = context;
        }

        // GET: api/Variable
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Variable>>> GetVariable()
        {
            return await _context.Variable
                                 .Include(v => v.Usuario)
                                 .ToListAsync();
        }

        // GET: api/Variable/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Variable>> GetVariable(int id)
        {
            var variable = await _context.Variable
                                         .Include(v => v.Usuario)
                                         .FirstOrDefaultAsync(v => v.Id == id);

            if (variable == null)
                return NotFound();

            return variable;
        }

        // POST: api/Variable
        [HttpPost]
        public async Task<ActionResult<Variable>> PostVariable(Variable variable)
        {
            variable.FechaCreacion = DateTime.UtcNow;

            _context.Variable.Add(variable);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVariable), new { id = variable.Id }, variable);
        }

        // PUT: api/Variable/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVariable(int id, Variable variable)
        {
            if (id != variable.Id)
                return BadRequest("El ID no coincide.");

            _context.Entry(variable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VariableExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Variable/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVariable(int id)
        {
            var variable = await _context.Variable.FindAsync(id);
            if (variable == null)
                return NotFound();

            _context.Variable.Remove(variable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VariableExists(int id)
        {
            return _context.Variable.Any(v => v.Id == id);
        }
    }
}

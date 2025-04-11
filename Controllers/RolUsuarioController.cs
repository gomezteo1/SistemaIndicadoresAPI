using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaIndicadoresAPI.Models;
using SistemaIndicadoresAPI.Data;

namespace SistemaIndicadoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolUsuarioController : ControllerBase
    {
        private readonly SistemaIndicadoresContext _context;

        public RolUsuarioController(SistemaIndicadoresContext context)
        {
            _context = context;
        }

        // GET: api/RolUsuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolUsuario>>> GetAll()
        {
            return await _context.RolUsuario.ToListAsync();
        }

        // GET: api/RolUsuario/{email}/{idRol}
        [HttpGet("{email}/{idRol}")]
        public async Task<ActionResult<RolUsuario>> GetById(string email, int idRol)
        {
            var item = await _context.RolUsuario
                .FirstOrDefaultAsync(x => x.FkEmail == email && x.FkIdRol == idRol);

            if (item == null)
                return NotFound();

            return item;
        }

        // POST: api/RolUsuario
        [HttpPost]
        public async Task<ActionResult<RolUsuario>> PostRolUsuario(RolUsuario ru)
        {
            _context.RolUsuario.Add(ru);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Exists(ru.FkEmail, ru.FkIdRol))
                    return Conflict("Ya existe una relación con ese email y rol.");
                else
                    throw;
            }

            return CreatedAtAction(nameof(GetById), new { email = ru.FkEmail, idRol = ru.FkIdRol }, ru);
        }

        // DELETE: api/RolUsuario/{email}/{idRol}
        [HttpDelete("{email}/{idRol}")]
        public async Task<IActionResult> DeleteRolUsuario(string email, int idRol)
        {
            var item = await _context.RolUsuario
                .FirstOrDefaultAsync(x => x.FkEmail == email && x.FkIdRol == idRol);

            if (item == null)
                return NotFound();

            _context.RolUsuario.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Exists(string email, int idRol)
        {
            return _context.RolUsuario.Any(x => x.FkEmail == email && x.FkIdRol == idRol);
        }
    }
}

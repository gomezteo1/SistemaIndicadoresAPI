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
    public class UsuarioController : ControllerBase
    {
        private readonly SistemaIndicadoresContext _context;

        public UsuarioController(SistemaIndicadoresContext context)
        {
            _context = context;
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuario.ToListAsync();
        }

        // GET: api/Usuario/{email}
        [HttpGet("{email}")]
        public async Task<ActionResult<Usuario>> GetUsuario(string email)
        {
            var usuario = await _context.Usuario.FindAsync(email);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // POST: api/Usuario
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuario), new { email = usuario.Email }, usuario);
        }

        // PUT: api/Usuario/{email}
        [HttpPut("{email}")]
        public async Task<IActionResult> PutUsuario(string email, Usuario usuario)
        {
            if (email != usuario.Email)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Usuario.Any(e => e.Email == email))
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
        
        [HttpGet("login/{email}")]
        public async Task<ActionResult<Usuario>> LoginUsuario(string email)
        {
            var usuario = await _context.Usuario.FindAsync(email);

            if (usuario == null)
            {
                return NotFound(new { message = "Usuario no encontrado" });
            }

            return usuario;
        }
        
        // DELETE: api/Usuario/{email}
        [HttpDelete("{email}")]
        public async Task<IActionResult> DeleteUsuario(string email)
        {
            var usuario = await _context.Usuario.FindAsync(email);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

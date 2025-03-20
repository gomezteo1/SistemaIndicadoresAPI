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
    public class UnidadMedicionController : ControllerBase
    {
        private readonly SistemaIndicadoresContext _context;

        public UnidadMedicionController(SistemaIndicadoresContext context)
        {
            _context = context;
        }

        // 🔹 GET: api/unidadmedicion (Obtener todas las unidades de medición)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnidadMedicion>>> GetUnidadesMedicion()
        {
            return await _context.UnidadMedicion.ToListAsync();
        }

        // 🔹 GET: api/unidadmedicion/5 (Obtener una unidad de medición por ID)
        [HttpGet("{id}")]
        public async Task<ActionResult<UnidadMedicion>> GetUnidadMedicion(int id)
        {
            var unidadMedicion = await _context.UnidadMedicion.FindAsync(id);

            if (unidadMedicion == null)
            {
                return NotFound(new { mensaje = "Unidad de medición no encontrada" });
            }

            return unidadMedicion;
        }

        // 🔹 POST: api/unidadmedicion (me Crear nueva unidad de medición)
        [HttpPost]
        public async Task<ActionResult<UnidadMedicion>> PostUnidadMedicion(UnidadMedicion unidadMedicion)
        {
            if (unidadMedicion == null || string.IsNullOrWhiteSpace(unidadMedicion.Descripcion))
            {
                return BadRequest(new { mensaje = "La descripción es requerida" });
            }

            _context.UnidadMedicion.Add(unidadMedicion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUnidadMedicion), new { id = unidadMedicion.Id }, unidadMedicion);
        }

        // 🔹 PUT: api/unidadmedicion/5 (Actualizar unidad de medición)
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnidadMedicion(int id, UnidadMedicion unidadMedicion)
        {
            if (id != unidadMedicion.Id)
            {
                return BadRequest(new { mensaje = "El ID de la URL no coincide con el ID del cuerpo" });
            }

            _context.Entry(unidadMedicion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.UnidadMedicion.Any(e => e.Id == id))
                {
                    return NotFound(new { mensaje = "Unidad de medición no encontrada" });
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // 🔹 DELETE: api/unidadmedicion/5 (Eliminar unidad de medición)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnidadMedicion(int id)
        {
            var unidadMedicion = await _context.UnidadMedicion.FindAsync(id);
            if (unidadMedicion == null)
            {
                return NotFound(new { mensaje = "Unidad de medición no encontrada" });
            }

            _context.UnidadMedicion.Remove(unidadMedicion);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

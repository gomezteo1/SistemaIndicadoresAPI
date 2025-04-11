using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaIndicadoresAPI.Data;

[ApiController]
[Route("api/[controller]")]
public class ResponsablesPorIndicadorController : ControllerBase
{
    private readonly SistemaIndicadoresContext _context;

    public ResponsablesPorIndicadorController(SistemaIndicadoresContext context)
    {
        _context = context;
    }

    // GET: api/ResponsablesPorIndicador
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ResponsablesPorIndicador>>> GetTodos()
    {
        return await _context.ResponsablesPorIndicador.ToListAsync();
    }

    // GET: api/ResponsablesPorIndicador/{fkResponsable}/{fkIndicador}
    [HttpGet("{fkResponsable}/{fkIndicador}")]
    public async Task<ActionResult<ResponsablesPorIndicador>> GetUno(string fkResponsable, int fkIndicador)
    {
        var relacion = await _context.ResponsablesPorIndicador
            .FirstOrDefaultAsync(r => r.FkIdResponsable == fkResponsable && r.FkIdIndicador == fkIndicador);

        if (relacion == null)
            return NotFound();

        return relacion;
    }

    // POST: api/ResponsablesPorIndicador
    [HttpPost]
    public async Task<ActionResult<ResponsablesPorIndicador>> Post(ResponsablesPorIndicador nuevaRelacion)
    {
        _context.ResponsablesPorIndicador.Add(nuevaRelacion);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUno), new { fkResponsable = nuevaRelacion.FkIdResponsable, fkIndicador = nuevaRelacion.FkIdIndicador }, nuevaRelacion);
    }

    // DELETE: api/ResponsablesPorIndicador/{fkResponsable}/{fkIndicador}
    [HttpDelete("{fkResponsable}/{fkIndicador}")]
    public async Task<IActionResult> Delete(string fkResponsable, int fkIndicador)
    {
        var relacion = await _context.ResponsablesPorIndicador
            .FirstOrDefaultAsync(r => r.FkIdResponsable == fkResponsable && r.FkIdIndicador == fkIndicador);

        if (relacion == null)
            return NotFound();

        _context.ResponsablesPorIndicador.Remove(relacion);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

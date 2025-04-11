using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaIndicadoresAPI.Data;

[ApiController]
[Route("api/[controller]")]
public class IndicadorController : ControllerBase
{
    private readonly SistemaIndicadoresContext _context;

    public IndicadorController(SistemaIndicadoresContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Indicador>>> GetIndicadores()
    {

        return await _context.Indicador.ToListAsync();

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Indicador>> GetIndicador(int id)
    {
        var indicador = await _context.Indicador.FindAsync(id);

        if (indicador == null)
            return NotFound();

        return Ok(indicador);
    }


    [HttpPost]
    public async Task<ActionResult<Indicador>> PostIndicador(Indicador indicador)
    {
        _context.Indicador.Add(indicador);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetIndicador), new { id = indicador.Id }, indicador);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutIndicador(int id, Indicador indicador)
    {
        if (id != indicador.Id)
        {
            return BadRequest("El ID del parámetro no coincide con el del objeto.");
        }

        _context.Entry(indicador).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!IndicadorExists(id))
            {
                return NotFound($"No se encontró el indicador con ID {id}.");
            }
            else
            {
                throw;
            }
        }

        return NoContent(); // 204 - éxito sin contenido
    }



    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteIndicador(int id)
    {
        var indicador = await _context.Indicador.FindAsync(id);
        if (indicador == null)
            return NotFound();

        _context.Indicador.Remove(indicador);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool IndicadorExists(int id)
    {
        return _context.Indicador.Any(e => e.Id == id);
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaIndicadoresAPI.Data;

[Route("api/[controller]")]
[ApiController]
public class ResultadoIndicadorController : ControllerBase
{
    private readonly SistemaIndicadoresContext _context;

    public ResultadoIndicadorController(SistemaIndicadoresContext context)
    {
        _context = context;
    }

    // GET: api/ResultadoIndicador
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ResultadoIndicador>>> GetResultadoIndicadores()
    {
        return await _context.Set<ResultadoIndicador>().ToListAsync();
    }

    // GET: api/ResultadoIndicador/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ResultadoIndicador>> GetResultadoIndicador(int id)
    {
        var resultado = await _context.Set<ResultadoIndicador>().FindAsync(id);

        if (resultado == null)
        {
            return NotFound();
        }

        return resultado;
    }

    // POST: api/ResultadoIndicador
    [HttpPost]
    public async Task<ActionResult<ResultadoIndicador>> PostResultadoIndicador(ResultadoIndicador resultado)
    {
        _context.Set<ResultadoIndicador>().Add(resultado);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetResultadoIndicador), new { id = resultado.Id }, resultado);
    }

    // PUT: api/ResultadoIndicador/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutResultadoIndicador(int id, ResultadoIndicador resultado)
    {
        if (id != resultado.Id)
        {
            return BadRequest();
        }

        _context.Entry(resultado).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ResultadoIndicadorExists(id))
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

    // DELETE: api/ResultadoIndicador/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteResultadoIndicador(int id)
    {
        var resultado = await _context.Set<ResultadoIndicador>().FindAsync(id);
        if (resultado == null)
        {
            return NotFound();
        }

        _context.Set<ResultadoIndicador>().Remove(resultado);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ResultadoIndicadorExists(int id)
    {
        return _context.Set<ResultadoIndicador>().Any(e => e.Id == id);
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaIndicadoresAPI.Data;

[ApiController]
[Route("api/[controller]")]
public class ArticuloController : ControllerBase
{
    private readonly SistemaIndicadoresContext _context;

    public ArticuloController(SistemaIndicadoresContext context)
    {
        _context = context;
    }

    // GET: api/articulo
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Articulo>>> GetArticulo()
    {
        return await _context.Articulo.ToListAsync();
    }

    // GET: api/articulo/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Articulo>> GetArticulo(string id)
    {
        var articulo = await _context.Articulo.FindAsync(id);
        if (articulo == null) return NotFound();
        return articulo;
    }

    // POST: api/articulo
    [HttpPost]
    public async Task<ActionResult<Articulo>> PostArticulo(Articulo articulo)
    {
        _context.Articulo.Add(articulo);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetArticulo), new { id = articulo.Id }, articulo);
    }

    // PUT: api/articulo/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutArticulo(string id, Articulo articulo)
    {
        if (id != articulo.Id) return BadRequest("ID del artículo no coincide.");

        _context.Entry(articulo).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Articulo.Any(e => e.Id == id)) return NotFound();
            else throw;
        }

        return NoContent();
    }

    // DELETE: api/articulo/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteArticulo(string id)
    {
        var articulo = await _context.Articulo.FindAsync(id);
        if (articulo == null) return NotFound();

        _context.Articulo.Remove(articulo);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaIndicadoresAPI.Data;
using SistemaIndicadoresAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class FuentesPorIndicadorController : ControllerBase
{
    private readonly SistemaIndicadoresContext _context;

    public FuentesPorIndicadorController(SistemaIndicadoresContext context)
    {
        _context = context;
    }

    // GET: api/FuentesPorIndicador
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FuentesPorIndicador>>> GetAll()
    {
        return await _context.FuentesPorIndicador.ToListAsync();
    }

    // GET: api/FuentesPorIndicador/5/3
    [HttpGet("{fkidfuente:int}/{fkidindicador:int}")]
    public async Task<ActionResult<FuentesPorIndicador>> GetById(int fkidfuente, int fkidindicador)
    {
        var item = await _context.FuentesPorIndicador
            .FirstOrDefaultAsync(x => x.FkIdFuente == fkidfuente && x.FkIdIndicador == fkidindicador);

        if (item == null)
            return NotFound();

        return item;
    }

    // POST: api/FuentesPorIndicador
    [HttpPost]
    public async Task<ActionResult<FuentesPorIndicador>> Create(FuentesPorIndicador item)
    {
        _context.FuentesPorIndicador.Add(item);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { fkidfuente = item.FkIdFuente, fkidindicador = item.FkIdIndicador }, item);
    }

    // DELETE: api/FuentesPorIndicador/5/3
    [HttpDelete("{fkidfuente:int}/{fkidindicador:int}")]
    public async Task<IActionResult> Delete(int fkidfuente, int fkidindicador)
    {
        var item = await _context.FuentesPorIndicador
            .FirstOrDefaultAsync(x => x.FkIdFuente == fkidfuente && x.FkIdIndicador == fkidindicador);

        if (item == null)
            return NotFound();

        _context.FuentesPorIndicador.Remove(item);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

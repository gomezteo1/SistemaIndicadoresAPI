using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaIndicadoresAPI.Data;
using SistemaIndicadoresAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class RepresenVisualPorIndicadorController : ControllerBase
{
    private readonly SistemaIndicadoresContext _context;

    public RepresenVisualPorIndicadorController(SistemaIndicadoresContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RepresenVisualPorIndicador>>> GetAll()
    {
        return await _context.RepresenVisualPorIndicador.ToListAsync();
    }

    [HttpGet("{idIndicador}/{idRepresenVisual}")]
    public async Task<ActionResult<RepresenVisualPorIndicador>> Get(int idIndicador, int idRepresenVisual)
    {
        var item = await _context.RepresenVisualPorIndicador.FindAsync(idIndicador, idRepresenVisual);
        if (item == null)
            return NotFound();

        return item;
    }

    [HttpPost]
    public async Task<ActionResult<RepresenVisualPorIndicador>> Post(RepresenVisualPorIndicador relacion)
    {
        _context.RepresenVisualPorIndicador.Add(relacion);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { idIndicador = relacion.FkIdIndicador, idRepresenVisual = relacion.FkIdRepresenVisual }, relacion);
    }

    [HttpDelete("{idIndicador}/{idRepresenVisual}")]
    public async Task<IActionResult> Delete(int idIndicador, int idRepresenVisual)
    {
        var item = await _context.RepresenVisualPorIndicador.FindAsync(idIndicador, idRepresenVisual);
        if (item == null)
            return NotFound();

        _context.RepresenVisualPorIndicador.Remove(item);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

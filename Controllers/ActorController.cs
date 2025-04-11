using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaIndicadoresAPI;
using SistemaIndicadoresAPI.Data;
using SistemaIndicadoresAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ActorController : ControllerBase
{
       private readonly SistemaIndicadoresContext _context;


    public ActorController(SistemaIndicadoresContext context)
    {
        _context = context;
    }

    // GET: api/actor
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Actor>>> GetActores()
    {
        return await _context.Actor
            .Include(a => a.TipoActor)
            .ToListAsync();
    }

    // GET: api/actor/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Actor>> GetActor(string id)
    {
        var actor = await _context.Actor
            .Include(a => a.TipoActor)
            .FirstOrDefaultAsync(a => a.Id == id);

        if (string.IsNullOrEmpty(actor.Id))
        {
            return NotFound();
        }

        return actor;
    }


    // POST: api/actor
    [HttpPost]
    public async Task<ActionResult<Actor>> PostActor(Actor actor)
    {
        _context.Actor.Add(actor);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetActor), new { id = actor.Id }, actor);
    }

    // PUT: api/actor/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutActor(string id, Actor actor)
    {
        if (id != actor.Id)
        {
            return BadRequest();
        }

        _context.Entry(actor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ActorExists(id))
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

    // DELETE: api/actor/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteActor(string id)
    {
        var actor = await _context.Actor.FindAsync(id);
        if (actor == null)
        {
            return NotFound();
        }

        _context.Actor.Remove(actor);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ActorExists(string id)
    {
        return _context.Actor.Any(e => e.Id == id);
    }
}

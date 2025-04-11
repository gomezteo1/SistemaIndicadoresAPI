using Microsoft.AspNetCore.Mvc;
using SistemaIndicadoresAPI.Repositories; 
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class BaseController<T, TKey> : ControllerBase where T : class
{
    private readonly IRepository<T, TKey> _repository;

    public BaseController(IRepository<T, TKey> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<T>>> GetAll()
    {
        var items = await _repository.GetAllAsync();
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<T>> GetById(TKey id)
    {
        var item = await _repository.GetByIdAsync(id);
        if (item == null) return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<T>> Create(T entity)
    {
        await _repository.AddAsync(entity);
        var entityId = entity.GetType().GetProperty("Id")?.GetValue(entity);
        return CreatedAtAction(nameof(GetById), new { id = entityId }, entity);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(TKey id, T entity)
    {
        if (!await _repository.ExistsAsync(id)) return NotFound();
        await _repository.UpdateAsync(entity);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(TKey id)
    {
        if (!await _repository.ExistsAsync(id)) return NotFound();
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}

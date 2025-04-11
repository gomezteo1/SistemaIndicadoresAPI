using Microsoft.AspNetCore.Mvc;
using SistemaIndicadoresAPI.Models;
using SistemaIndicadoresAPI.Repositories;

namespace SistemaIndicadoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SentidoController : ControllerBase
    {
        private readonly IRepository<Sentido, int> _repository;

        public SentidoController(IRepository<Sentido, int> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sentidos = await _repository.GetAllAsync();
            return Ok(sentidos);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using SistemaIndicadoresAPI.Models;
using SistemaIndicadoresAPI.Repositories; // <-- Agrega esto

namespace SistemaIndicadoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoIndicadorController : BaseController<TipoIndicador, int>
    {
        public TipoIndicadorController(IRepository<TipoIndicador, int> repository) : base(repository) { }
    }
}

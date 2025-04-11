using Microsoft.AspNetCore.Mvc;
using SistemaIndicadoresAPI.Models;
using SistemaIndicadoresAPI.Repositories;

namespace SistemaIndicadoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoActorController : BaseController<TipoActor, int>
    {
        public TipoActorController(IRepository<TipoActor, int> repository) : base(repository) { }
    }
}

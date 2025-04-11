using Microsoft.AspNetCore.Mvc;
using SistemaIndicadoresAPI.Models;
using SistemaIndicadoresAPI.Repositories;

namespace SistemaIndicadoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadMedicionController : BaseController<UnidadMedicion, int>
    {
        public UnidadMedicionController(IRepository<UnidadMedicion, int> repository) : base(repository) { }
    }
}

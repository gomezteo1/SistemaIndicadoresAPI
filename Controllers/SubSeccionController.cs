using Microsoft.AspNetCore.Mvc;
using SistemaIndicadoresAPI.Models;
using SistemaIndicadoresAPI.Repositories;

namespace SistemaIndicadoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubseccionController : BaseController<Subseccion, string>
    {
        public SubseccionController(IRepository<Subseccion, string> repository) : base(repository) { }
    }
}

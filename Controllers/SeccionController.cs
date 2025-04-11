using Microsoft.AspNetCore.Mvc;
using SistemaIndicadoresAPI.Models;
using SistemaIndicadoresAPI.Repositories;

namespace SistemaIndicadoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeccionController : BaseController<Seccion, string>
    {
        public SeccionController(IRepository<Seccion, string> repository) : base(repository) { }
    }
}

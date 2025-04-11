using Microsoft.AspNetCore.Mvc;
using SistemaIndicadoresAPI.Models;
using SistemaIndicadoresAPI.Repositories;

[Route("api/[controller]")]
[ApiController]
// se optimizó código
public class RolController : BaseController<Rol, int>
{
    public RolController(IRepository<Rol, int> repository) : base(repository) { }
}

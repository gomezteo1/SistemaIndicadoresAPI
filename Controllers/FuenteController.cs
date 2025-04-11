using Microsoft.AspNetCore.Mvc;
using SistemaIndicadoresAPI.Models;
using SistemaIndicadoresAPI.Repositories;

[Route("api/[controller]")]
[ApiController]
public class FuenteController : BaseController<Fuente, int>
{
    public FuenteController(IRepository<Fuente, int> repository) : base(repository) { }
}

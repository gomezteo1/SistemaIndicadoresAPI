using Microsoft.AspNetCore.Mvc;
using SistemaIndicadoresAPI.Models;
using SistemaIndicadoresAPI.Repositories;

[Route("api/[controller]")]
[ApiController]
public class FrecuenciaController : BaseController<Frecuencia, int>
{
    public FrecuenciaController(IRepository<Frecuencia, int> repository) : base(repository) { }
}

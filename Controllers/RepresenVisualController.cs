using Microsoft.AspNetCore.Mvc;
using SistemaIndicadoresAPI.Models;
using SistemaIndicadoresAPI.Repositories;

[Route("api/[controller]")]
[ApiController]
// se optimizó código
public class RepresenVisualController : BaseController<RepresenVisual, int>
{
    public RepresenVisualController(IRepository<RepresenVisual, int> repository) : base(repository) { }
}

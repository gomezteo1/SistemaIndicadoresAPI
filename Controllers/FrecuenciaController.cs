using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaIndicadoresAPI;
using SistemaIndicadoresAPI.Data;
using SistemaIndicadoresAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
//se optimizo codigo
public class FrecuenciaController : BaseController<Frecuencia>
{
    public FrecuenciaController(IRepository<Frecuencia> repository) : base(repository) { }
}

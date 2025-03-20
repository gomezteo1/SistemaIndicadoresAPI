using Microsoft.EntityFrameworkCore;
using SistemaIndicadoresAPI.Models;

namespace SistemaIndicadoresAPI.Data
{
    public class SistemaIndicadoresContext : DbContext
    {
        public SistemaIndicadoresContext(DbContextOptions<SistemaIndicadoresContext> options)
            : base(options) { }
        public DbSet<Indicador> Indicador { get; set; }
        public DbSet<Literal> Literal { get; set; }
        public DbSet<Numeral> Numeral { get; set; }
        public DbSet<Paragrafo> Paragrafo { get; set; }
        public DbSet<RepresenVisual> RepresenVisual { get; set; }
        public DbSet<RepresenVisualPorIndicador> RepresenVisualPorIndicador { get; set; }
        public DbSet<ResponsablesPorIndicador> ResponsablesPorIndicador { get; set; }
        public DbSet<ResultadoIndicador> ResultadoIndicador { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<RolUsuario> RolUsuario { get; set; }
        public DbSet<Sentido> Sentido { get; set; }
        public DbSet<Seccion> Seccion { get; set; }
        public DbSet<Subseccion> Subseccion { get; set; }
        public DbSet<Fuente> Fuente { get; set; }
        public DbSet<TipoActor> TipoActor { get; set; }
        public DbSet<TipoIndicador> TipoIndicador { get; set; }
        public DbSet<TipoIndicador> TipoIndicadores { get; set; }

        public DbSet<UnidadMedicion> UnidadesMedicion { get; set; }
        public DbSet<UnidadMedicion> UnidadMedicion { get; set; } = null!;
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Variable> Variable { get; set; }
        public DbSet<VariablesPorIndicador> VariablesPorIndicador { get; set; }
        public DbSet<Frecuencia> Frecuencia { get; set; }
    }
}

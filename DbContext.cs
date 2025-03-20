// using Microsoft.EntityFrameworkCore;
// using SistemaIndicadoresAPI.Models;

// namespace SistemaIndicadoresAPI.Data
// {
//     public class SistemaIndicadoresContext : DbContext
//     {
//         public SistemaIndicadoresContext(DbContextOptions<SistemaIndicadoresContext> options)
//             : base(options) { }

//         public DbSet<Literal> Literales { get; set; }
//         public DbSet<Numeral> Numerales { get; set; }
//         public DbSet<Paragrafo> Paragrafos { get; set; }
//         public DbSet<RepresenVisual> RepresenVisuales { get; set; }
//         public DbSet<RepresenVisualPorIndicador> RepresenVisualPorIndicadores { get; set; }
//         public DbSet<ResponsablesPorIndicador> ResponsablesPorIndicadores { get; set; }
//         public DbSet<ResultadoIndicador> ResultadoIndicadores { get; set; }
//         public DbSet<Rol> Roles { get; set; }
//         public DbSet<RolUsuario> RolUsuarios { get; set; }
//         public DbSet<Seccion> Secciones { get; set; }
//         public DbSet<Sentido> Sentidos { get; set; }
//         public DbSet<Subseccion> Subsecciones { get; set; }
//         public DbSet<TipoActor> TipoActores { get; set; }
//         public DbSet<TipoIndicador> TipoIndicadores { get; set; }
//         public DbSet<UnidadMedicion> UnidadesMedicion { get; set; }
//         public DbSet<Usuario> Usuarios { get; set; }
//         public DbSet<Variable> Variables { get; set; }
//         public DbSet<VariablesPorIndicador> VariablesPorIndicador { get; set; }
//         public DbSet<Frecuencia> Frecuencias { get; set; }
//     }
// }

using Microsoft.EntityFrameworkCore;
using SistemaIndicadoresAPI.Models;

namespace SistemaIndicadoresAPI.Data
{
    public class SistemaIndicadoresContext : DbContext
    {
        public SistemaIndicadoresContext(DbContextOptions<SistemaIndicadoresContext> options)
            : base(options) { }

        // DbSets (evitamos duplicados y nombres ambiguos)
        public DbSet<Actor> Actor { get; set; }
        public DbSet<Articulo> Articulo { get; set; }
        public DbSet<Fuente> Fuente { get; set; }
        public DbSet<Frecuencia> Frecuencia { get; set; }
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
        public DbSet<Seccion> Seccion { get; set; }
        public DbSet<Sentido> Sentido { get; set; }
        public DbSet<Subseccion> Subseccion { get; set; }
        public DbSet<TipoActor> TipoActor { get; set; }
        public DbSet<TipoIndicador> TipoIndicador { get; set; }
        public DbSet<UnidadMedicion> UnidadMedicion { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Variable> Variable { get; set; }
        public DbSet<VariablePorIndicador> VariablePorIndicador { get; set; }
        public DbSet<FuentesPorIndicador> FuentesPorIndicador { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // FuentesPorIndicador (compuesta)
            modelBuilder.Entity<FuentesPorIndicador>()
                .HasKey(f => new { f.FkIdFuente, f.FkIdIndicador });

            modelBuilder.Entity<FuentesPorIndicador>()
                .HasOne(f => f.Fuente)
                .WithMany()
                .HasForeignKey(f => f.FkIdFuente);

            modelBuilder.Entity<FuentesPorIndicador>()
                .HasOne(f => f.Indicador)
                .WithMany()
                .HasForeignKey(f => f.FkIdIndicador);

            // RepresenVisualPorIndicador (compuesta)
            modelBuilder.Entity<RepresenVisualPorIndicador>()
                .HasKey(r => new { r.FkIdIndicador, r.FkIdRepresenVisual });

            modelBuilder.Entity<RepresenVisualPorIndicador>()
                .HasOne(r => r.Indicador)
                .WithMany()
                .HasForeignKey(r => r.FkIdIndicador)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RepresenVisualPorIndicador>()
                .HasOne(r => r.RepresenVisual)
                .WithMany()
                .HasForeignKey(r => r.FkIdRepresenVisual)
                .OnDelete(DeleteBehavior.Cascade);

            // ResponsablesPorIndicador (compuesta)
            modelBuilder.Entity<ResponsablesPorIndicador>()
                .HasKey(r => new { r.FkIdResponsable, r.FkIdIndicador });

            // RolUsuario (compuesta y relaciones)
            modelBuilder.Entity<RolUsuario>()
                .HasKey(ru => new { ru.FkEmail, ru.FkIdRol });

            modelBuilder.Entity<RolUsuario>()
                .HasOne(ru => ru.Usuario)
                .WithMany(u => u.RolUsuarios) // <-- propiedad en Usuario
                .HasForeignKey(ru => ru.FkEmail)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RolUsuario>()
                .HasOne(ru => ru.Rol)
                .WithMany() // puedes agregar .WithMany(r => r.RolUsuarios) si agregas colección en Rol
                .HasForeignKey(ru => ru.FkIdRol)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

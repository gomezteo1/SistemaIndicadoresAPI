using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaIndicadoresAPI.Models
{
    public class VariablesPorIndicador
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int FkIdVariable { get; set; }

        [Required]
        public int FkIdIndicador { get; set; }

        [Required]
        public float Dato { get; set; }

        [Required]
        [StringLength(100)]
        public string FkEmailUsuario { get; set; } = string.Empty;

        [Required]
        public DateTime FechaDato { get; set; }

        // Relaciones con las otras tablas (Opcional)
        [ForeignKey("FkIdVariable")]
        public Variable? Variable { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaIndicadoresAPI.Models
{
    public class Variable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public DateTime FechaCreacion { get; set; }

        [Required]
        [StringLength(100)]
        public string FkEmailUsuario { get; set; } = string.Empty;
    }
}

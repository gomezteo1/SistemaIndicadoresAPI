using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SistemaIndicadoresAPI.Models
{
    public class Variable
    {
        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string? Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string? FkEmailUsuario { get; set; }

        [JsonIgnore]
        [ForeignKey("FkEmailUsuario")]
        public Usuario? Usuario { get; set; }
    }
}

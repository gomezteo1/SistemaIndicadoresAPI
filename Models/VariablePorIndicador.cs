using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SistemaIndicadoresAPI.Models
{
    [Table("variablesporindicador")]
    public class VariablePorIndicador
    {
        [Key]
        public int Id { get; set; }
        public int FkIdVariable { get; set; }
        public int FkIdIndicador { get; set; }
        public double Dato { get; set; }
        public string FkEmailUsuario { get; set; } = null!;
        public DateTime FechaDato { get; set; }
        [JsonIgnore]
        [ForeignKey("FkIdVariable")]
        public virtual Variable? Variable { get; set; }
        [JsonIgnore]
        [ForeignKey("FkIdIndicador")]
        public virtual Indicador? Indicador { get; set; }
        [JsonIgnore]
        [ForeignKey("FkEmailUsuario")]
        public virtual Usuario? Usuario { get; set; }
    }
}

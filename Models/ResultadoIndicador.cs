using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class ResultadoIndicador
{
    [Key]
    public int Id { get; set; }

    [Required]
    public double Resultado { get; set; }

    [Required]
    public DateTime FechaCalculo { get; set; }

    [Required]
    public int FkIdIndicador { get; set; }

    [JsonIgnore]
    [ForeignKey("FkIdIndicador")]
    public virtual Indicador? Indicador { get; set; }
}

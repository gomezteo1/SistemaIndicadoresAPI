using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
//Modelo: FuentePorIndicador.cs (Depende de Fuente, Indicador)
public class FuentePorIndicador
{
    [Key]
    public int Id { get; set; }

    public int FuenteId { get; set; }
    [JsonIgnore]
    [ForeignKey("FuenteId")]
    public required virtual Fuente Fuente { get; set; }

    public int IndicadorId { get; set; }
    [JsonIgnore]
    [ForeignKey("IndicadorId")]
    public required virtual Indicador Indicador { get; set; }
}

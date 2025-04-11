using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class FuentesPorIndicador
{
    [ForeignKey("Fuente")]
    public int FkIdFuente { get; set; }

    [JsonIgnore]
    public virtual Fuente? Fuente { get; set; }

    [ForeignKey("Indicador")]
    public int FkIdIndicador { get; set; }

    [JsonIgnore]
    public virtual Indicador? Indicador { get; set; }
}

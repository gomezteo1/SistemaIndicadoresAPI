using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class ResponsablesPorIndicador
{
    [Key, Column(Order = 0)]
    public string FkIdResponsable { get; set; } = null!;

    [Key, Column(Order = 1)]
    public int FkIdIndicador { get; set; }

    public DateTime FechaAsignacion { get; set; } = DateTime.Now;

    [JsonIgnore]
    [ForeignKey("FkIdResponsable")]
    public virtual Usuario? Responsable { get; set; }

    [JsonIgnore]
    [ForeignKey("FkIdIndicador")]
    public virtual Indicador? Indicador { get; set; }
}

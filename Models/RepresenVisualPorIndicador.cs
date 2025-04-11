using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class RepresenVisualPorIndicador
{
    public int FkIdIndicador { get; set; }

    [JsonIgnore]
    [ForeignKey("FkIdIndicador")]
    public virtual Indicador? Indicador { get; set; }

    public int FkIdRepresenVisual { get; set; }

    [JsonIgnore]
    [ForeignKey("FkIdRepresenVisual")]
    public virtual RepresenVisual? RepresenVisual { get; set; }
}

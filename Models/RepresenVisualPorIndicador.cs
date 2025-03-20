using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class RepresenVisualPorIndicador
{
    [Key]
    public int Id { get; set; }

    public int IndicadorId { get; set; }
    [ForeignKey("IndicadorId")]
    public required virtual Indicador Indicador { get; set; }

    public int RepresenVisualId { get; set; }
    [ForeignKey("RepresenVisualId")]
    public required virtual RepresenVisual RepresenVisual { get; set; }
}

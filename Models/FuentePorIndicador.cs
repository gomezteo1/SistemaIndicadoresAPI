using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//Modelo: FuentePorIndicador.cs (Depende de Fuente, Indicador)
public class FuentePorIndicador
{
    [Key]
    public int Id { get; set; }

    public int FuenteId { get; set; }
    [ForeignKey("FuenteId")]
    public required virtual Fuente Fuente { get; set; }

    public int IndicadorId { get; set; }
    [ForeignKey("IndicadorId")]
    public required virtual Indicador Indicador { get; set; }
}

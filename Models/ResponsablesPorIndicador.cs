using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//Modelo: ResponsablesPorIndicador.cs (Depende de Indicador, Actor)
public class ResponsablesPorIndicador
{
    [Key]
    public string Id { get; set; }

    public int IndicadorId { get; set; }
    [ForeignKey("IndicadorId")]
    public required virtual Indicador Indicador { get; set; }

    public string ActorId { get; set; }
    [ForeignKey("ActorId")]
    public required virtual Actor Actor { get; set; }
}

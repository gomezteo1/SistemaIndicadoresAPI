using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//Modelo: ResultadoIndicador.cs (Depende de Indicador)
public class ResultadoIndicador
{
    [Key]
    public int Id { get; set; }

    public int IndicadorId { get; set; }
    [ForeignKey("IndicadorId")]
    public required virtual Indicador Indicador { get; set; }

    public decimal Resultado { get; set; }
    public DateTime FechaCalculo { get; set; }
}

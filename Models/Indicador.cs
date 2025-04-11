using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SistemaIndicadoresAPI.Models;

//Modelo: Indicador.cs (Depende de varias tablas) 
//Tabla fuerte o negocio
public class Indicador
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public required string Nombre { get; set; }

    public int TipoIndicadorId { get; set; }
    [ForeignKey("TipoIndicadorId")]
    public required  virtual TipoIndicador TipoIndicador { get; set; }

    public int UnidadMedicionId { get; set; }
    [ForeignKey("UnidadMedicionId")]
    public required virtual UnidadMedicion UnidadMedicion { get; set; }

    public int? SentidoId { get; set; }
    [ForeignKey("SentidoId")]
    public required virtual Sentido Sentido { get; set; }

    public int FrecuenciaId { get; set; }
    [ForeignKey("FrecuenciaId")]
    public required virtual Frecuencia Frecuencia { get; set; }

    public string? ArticuloId { get; set; }
    [ForeignKey("ArticuloId")]
    public virtual Articulo? Articulo { get; set; }

    public int? LiteralId { get; set; }
    [ForeignKey("LiteralId")]
    public virtual Literal? Literal { get; set; }

    public int? NumeralId { get; set; }
    [ForeignKey("NumeralId")]
    public virtual Numeral? Numeral { get; set; }

    public int? ParagrafoId { get; set; }
    [ForeignKey("ParagrafoId")]
    public virtual Paragrafo? Paragrafo { get; set; }
}

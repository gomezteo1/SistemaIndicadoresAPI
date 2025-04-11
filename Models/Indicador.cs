using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Indicador
{
    [Key]
    public int Id { get; set; }

    
    [MaxLength(50)]
    public  string? Codigo { get; set; }

    
    [MaxLength(200)]
    public  string? Nombre { get; set; }

    [MaxLength(500)]
    public string? Objetivo { get; set; }

    [MaxLength(500)]
    public string? Alcance { get; set; }

    [MaxLength(500)]
    public string? Formula { get; set; }

    public int FkIdTipoIndicador { get; set; }
    [JsonIgnore]
    [ForeignKey("FkIdTipoIndicador")]
    public  virtual TipoIndicador? TipoIndicador { get; set; }

    public int FkIdUnidadMedicion { get; set; }
    [JsonIgnore]
    [ForeignKey("FkIdUnidadMedicion")]
    public virtual UnidadMedicion? UnidadMedicion { get; set; }

    public string? Meta { get; set; } // Antes decimal?, ahora string porque en DB es varchar

    public int? FkIdSentido { get; set; }
    [JsonIgnore]
    [ForeignKey("FkIdSentido")]
    public virtual Sentido? Sentido { get; set; }

    public int FkIdFrecuencia { get; set; }
    [JsonIgnore]
    [ForeignKey("FkIdFrecuencia")]
    public virtual Frecuencia? Frecuencia { get; set; }

    public string? FkIdArticulo { get; set; }
    [JsonIgnore]
    [ForeignKey("FkIdArticulo")]
    public virtual Articulo? Articulo { get; set; }

    public string? FkIdLiteral { get; set; } // Antes int?, ahora string
    [JsonIgnore]
    [ForeignKey("FkIdLiteral")]
    public virtual Literal? Literal { get; set; }

    public string? FkIdNumeral { get; set; } // Antes int?, ahora string
    [JsonIgnore]
    [ForeignKey("FkIdNumeral")]
    public virtual Numeral? Numeral { get; set; }

    public string? FkIdParagrafo { get; set; } // Antes int?, ahora string
    [JsonIgnore]
    [ForeignKey("FkIdParagrafo")]
    public virtual Paragrafo? Paragrafo { get; set; }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
//Modelo: Literal.cs (Depende de Articulo)
public class Literal
{
    [Key]
    public string? Id { get; set; }
    public  string? Descripcion { get; set; }
    public string? FkIdArticulo { get; set; }
    [JsonIgnore]
    [ForeignKey("FkIdArticulo")]
    public virtual Articulo? Articulo { get; set; }
}

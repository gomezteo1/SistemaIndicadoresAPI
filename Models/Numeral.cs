using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
//Modelo: Numeral.cs (Depende de Literal)
public class Numeral
{
    [Key]
    public string? Id { get; set; }

    public string? Descripcion { get; set; }

    public string? FkIdLiteral { get; set; }
    [JsonIgnore]
    [ForeignKey("FkIdLiteral")] 
    public virtual Literal? Literal { get; set; }
}

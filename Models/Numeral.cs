using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//Modelo: Numeral.cs (Depende de Literal)
public class Numeral
{
    [Key]
    public string? Id { get; set; }

    public required string Nombre { get; set; }

    public string? LiteralId { get; set; }
    [ForeignKey("LiteralId")]
    public required virtual Literal Literal { get; set; }
}

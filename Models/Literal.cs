using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//Modelo: Literal.cs (Depende de Articulo)
public class Literal
{
    [Key]
    public int Id { get; set; }

    public required string Nombre { get; set; }

    public int ArticuloId { get; set; }
    [ForeignKey("ArticuloId")]
    public required virtual Articulo Articulo { get; set; }
}

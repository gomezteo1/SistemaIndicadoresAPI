using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//Modelo: Paragrafo.cs (Depende de Articulo)    
public class Paragrafo
{
    [Key]
    public int Id { get; set; }

    public required string Nombre { get; set; }

    public int ArticuloId { get; set; }
    [ForeignKey("ArticuloId")]
    public required virtual Articulo Articulo { get; set; }
}

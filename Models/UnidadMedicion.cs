using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UnidadMedicion
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Descripcion { get; set; } = string.Empty;
}

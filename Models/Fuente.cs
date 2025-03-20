using System.ComponentModel.DataAnnotations;

public class Fuente
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(2000)]
    public required string Nombre { get; set; }
}

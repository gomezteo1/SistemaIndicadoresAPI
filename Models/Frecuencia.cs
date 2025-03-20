using System.ComponentModel.DataAnnotations;

public class Frecuencia
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(200)]
    public required string Nombre { get; set; }
}

using System.ComponentModel.DataAnnotations;

public class Subseccion
{
    [Key]
    public required string Id { get; set; }
    
    [Required]
    [MaxLength(200)]
    public required string Nombre { get; set; }
}

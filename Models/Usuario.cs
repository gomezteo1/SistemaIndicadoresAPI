using System.ComponentModel.DataAnnotations;

public class Usuario
{
    [Key]
    [MaxLength(100)]
    public required string Email { get; set; }
    
    [Required]
    [MaxLength(100)]
    public required string Contrasena { get; set; }
}

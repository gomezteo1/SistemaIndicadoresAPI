using System.ComponentModel.DataAnnotations;

public class Usuario
{
    [Key]
    [MaxLength(100)]
    [Required(ErrorMessage = "El email es obligatorio.")]
    [EmailAddress(ErrorMessage = "Formato de email inválido.")]
    public required string Email { get; set; }
    
    [Required]
    [MaxLength(100)]
    [Required(ErrorMessage = "La contraseña es obligatoria.")]
    [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
    public required string Contrasena { get; set; }
}

using System.ComponentModel.DataAnnotations;

public class Rol
{
   [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(200)]
    public required string Nombre { get; set; }

    public ICollection<RolUsuario> RolUsuarios { get; set; } = new List<RolUsuario>();
}

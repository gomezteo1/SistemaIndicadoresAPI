using System.ComponentModel.DataAnnotations;

public class Seccion
{   [Key]
    public required string Id { get; set; }
    //recordar que la clave no pasa de 99 
    [Required]
    [MaxLength(200)]
    public required string Nombre { get; set; }
}

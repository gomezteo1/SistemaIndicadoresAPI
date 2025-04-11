using System.ComponentModel.DataAnnotations;


    public class Sentido
    {
       [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(200)]
    public required string Nombre { get; set; }
    }


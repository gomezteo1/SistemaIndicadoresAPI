using System.ComponentModel.DataAnnotations;

public class RepresenVisual
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public required string Nombre { get; set; }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//Modelo: Actor.cs (Depende de TipoActor)
public class Actor
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public required  string Nombre { get; set; }

    public int TipoActorId { get; set; }
    [ForeignKey("TipoActorId")]
    public required virtual TipoActor TipoActor { get; set; }
}

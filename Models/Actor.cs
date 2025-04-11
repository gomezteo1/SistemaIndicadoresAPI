using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Actor
{
    [Key]
    public required string Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Nombre { get; set; }

    public int FkIdTipoActor { get; set; }

    [ForeignKey("FkIdTipoActor")]
    public TipoActor TipoActor { get; set; } = null!;
}

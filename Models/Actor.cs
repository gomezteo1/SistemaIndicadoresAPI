using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Actor
{
    [Key]
    public required string Id { get; set; }

    [StringLength(255)]
    public required string Nombre { get; set; }

    public int FkIdTipoActor { get; set; }

    [JsonIgnore]
    [ForeignKey("FkIdTipoActor")]
    public TipoActor? TipoActor { get; set; }
}

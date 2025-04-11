using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
<<<<<<< HEAD
using Microsoft.EntityFrameworkCore;
using SistemaIndicadoresAPI.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
=======
using System.Text.Json.Serialization;
>>>>>>> be6b69498090f03faf1065325d2890ba9d838805

public class Actor
{
    [Key]
    public required string Id { get; set; }

    [StringLength(255)]
    public required string Nombre { get; set; }

    public int FkIdTipoActor { get; set; }

    [JsonIgnore]
    [ForeignKey("FkIdTipoActor")]
<<<<<<< HEAD
    public int FkIdTipoActor { get; set; } 

    public required TipoActor? TipoActor { get; set; } = null!;
=======
    public TipoActor? TipoActor { get; set; }
>>>>>>> be6b69498090f03faf1065325d2890ba9d838805
}

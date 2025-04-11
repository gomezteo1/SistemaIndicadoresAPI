using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Actor
{
    [Key]
    public required string Id { get; set; } = string.Empty;
    [Required]
    [StringLength(255)]
    public string Nombre { get; set; }= string.Empty;
    [ForeignKey("FkIdTipoActor")]
    public int FkIdTipoActor { get; set; } 

    public TipoActor? TipoActor { get; set; } = null!;
}



// public class Actor
// {
    
//     public  string Id { get; set; }

 
//     public string Nombre { get; set; }

//     public int FkIdTipoActor { get; set; }

//     
//     public TipoActor TipoActor { get; set; }
// }

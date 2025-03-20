using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class RolUsuario
{
    [Key]
    public int Id { get; set; }

    public required string UsuarioEmail { get; set; }
    [ForeignKey("UsuarioEmail")]
    public required virtual Usuario Usuario { get; set; }

    public int RolId { get; set; }
    [ForeignKey("RolId")]
    public required virtual Rol Rol { get; set; }
}

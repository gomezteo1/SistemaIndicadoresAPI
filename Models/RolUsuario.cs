using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
[Table("rol_usuario")]
public class RolUsuario
{
    public string FkEmail { get; set; } = null!;

    public int FkIdRol { get; set; }

    [JsonIgnore]
    [ForeignKey("FkEmail")]
    public virtual Usuario? Usuario { get; set; }

    
    [ForeignKey("FkIdRol")]
    public virtual Rol? Rol { get; set; }
}

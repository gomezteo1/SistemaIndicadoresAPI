using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
public class Articulo
{
    [Key]
    public string Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string FkIdSeccion { get; set; }
    public string FkIdSubseccion { get; set; }

    [JsonIgnore]
    [ForeignKey("FkIdSeccion")]
    public Seccion? Seccion { get; set; }

    [JsonIgnore]
    [ForeignKey("FkIdSubseccion")]
    public Subseccion? Subseccion { get; set; }
}

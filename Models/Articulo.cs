using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
public class Articulo
{
    [Key]
    public int Id { get; set; }

    public string Nombre { get; set; }


    public string? Descripcion { get; set; }


    public int FkIdSeccion { get; set; }

    public int FkIdSubseccion { get; set; }

    [JsonIgnore]
    [ForeignKey("FkIdSeccion")]
    public Seccion? Seccion { get; set; }

    [JsonIgnore]
    [ForeignKey("FkIdSubseccion")]
    public Subseccion? Subseccion { get; set; }
}

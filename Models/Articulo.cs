public class Articulo
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;  
 
    public int SeccionId { get; set; }
    public required Seccion Seccion { get; set; }
    //public Seccion Seccion { get; set; } = new Seccion();  
    
}

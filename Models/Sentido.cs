using System.ComponentModel.DataAnnotations;

namespace SistemaIndicadoresAPI.Models
{
    public class Sentido
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}

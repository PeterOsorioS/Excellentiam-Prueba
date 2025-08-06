using Excellentiam.Models.Enum;

namespace Excellentiam.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Correo { get; set; }
    public string Contraseña { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    public ICollection<Tarea> Tareas { get; set; }
}

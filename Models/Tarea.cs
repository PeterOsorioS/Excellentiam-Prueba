using Excellentiam.Models.Enum;

namespace Excellentiam.Models;

public class Tarea
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descripcion { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    public EstadoTarea Estado { get; set; } = EstadoTarea.Pendiente;
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
}

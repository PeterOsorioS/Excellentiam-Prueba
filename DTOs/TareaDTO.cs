using Excellentiam.Models.Enum;

namespace Excellentiam.DTOs;

public record TareaDTO
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descripcion { get; set; }
    public DateTime FechaCreacion { get; set; }
    public string Estado { get; set; }
}

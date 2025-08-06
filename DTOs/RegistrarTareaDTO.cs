using System.ComponentModel.DataAnnotations;

namespace Excellentiam.DTOs;

public record RegistrarTareaDTO
{
    [Required(ErrorMessage = "El Titulo es obligatorio.")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "La fecha es obligatorio.")]
    public DateTime Fecha { get; set; } = DateTime.UtcNow;

    [Required(ErrorMessage = "La Descripcion es obligatoria.")]
    public string Descripcion { get; set; }
}

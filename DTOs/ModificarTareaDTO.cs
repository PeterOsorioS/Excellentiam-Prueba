using System.ComponentModel.DataAnnotations;

namespace Excellentiam.DTOs;

public class ModificarTareaDTO
{
    [Required(ErrorMessage = "El Titulo es obligatorio.")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "La fecha es obligatorio.")]
    public DateTime Fecha { get; set; } = DateTime.UtcNow;

    [Required(ErrorMessage = "El estado es obligatorio.")]
    public int Estado {  get; set; }

    [Required(ErrorMessage = "La Descripcion es obligatoria.")]
    public string Descripcion { get; set; }
}

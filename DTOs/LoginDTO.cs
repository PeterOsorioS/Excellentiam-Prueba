using System.ComponentModel.DataAnnotations;

namespace Excellentiam.DTOs;

public record LoginDTO
{
    [Required(ErrorMessage = "El correo es obligatorio.")]
    public string Correo {  get; set; }
    [Required(ErrorMessage ="La contraseña es obligatoria.")]
    public string Contraseña { get; set; }
}

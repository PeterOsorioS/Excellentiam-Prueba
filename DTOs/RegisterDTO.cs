using System.ComponentModel.DataAnnotations;

namespace Excellentiam.DTOs;

public class RegisterDTO
{
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El correo es obligatorio.")]
    public string Correo { get; set; }

    [Required(ErrorMessage = "La contraseña es obligatoria.")]
    public string Contraseña { get; set; }

    [Required(ErrorMessage = "La contraseña es obligatoria.")]
    [Compare("Contraseña", ErrorMessage = "Las constraseñas no coinciden")]
    public string ConfirmarContraseña { get; set; }
}

using Excellentiam.DTOs;

namespace Excellentiam.Service.Interface;

public interface ITareaService
{
    Task<IEnumerable<TareaDTO>> ObtenerTareas(int id);
    Task<TareaDTO> ObtenerTareaPorId(int id);
    Task<bool> RegistrarTarea(RegistrarTareaDTO registrarTareaDTO);
}

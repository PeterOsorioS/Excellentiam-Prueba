using Excellentiam.Models;
using GenericRepositoryZ;

namespace Excellentiam.Data.Repository.Interface;

public interface ITareaRepository : IRepository<Tarea>
{
    Task<bool> ExistenTareasUsuario(int usuarioId);
}

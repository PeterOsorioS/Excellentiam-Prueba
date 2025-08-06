using Excellentiam.Data.Repository.Interface;
using Excellentiam.Models;
using GenericRepositoryZ;
using Microsoft.EntityFrameworkCore;

namespace Excellentiam.Data.Repository.impl;

public class TareaRepository : Repository<Tarea>, ITareaRepository
{
    private readonly ApplicationDbContext _db;
    public TareaRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public async Task<bool> ExistenTareasUsuario(int usuarioId)
    {
        return await _db.Tareas.AnyAsync(t => t.UsuarioId == usuarioId);
    }
}

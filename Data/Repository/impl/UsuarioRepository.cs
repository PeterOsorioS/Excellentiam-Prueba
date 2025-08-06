using Excellentiam.Data;
using Excellentiam.Data.Repository.Interface;
using Excellentiam.Models;
using GenericRepositoryZ;

namespace Excellentiam.Data.Repository.impl;

public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
{
    private readonly ApplicationDbContext _db;
    public UsuarioRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
}

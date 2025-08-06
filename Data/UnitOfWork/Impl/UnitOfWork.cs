using Excellentiam.Data.Repository.impl;
using Excellentiam.Data.Repository.Interface;
using Excellentiam.Data.UnitOfWork.Interface;
using Microsoft.EntityFrameworkCore.Storage;

namespace Excellentiam.Data.UnitOfWork.Impl;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _db;
    public UnitOfWork(ApplicationDbContext db)
    {
        _db = db;
        Usuario = new UsuarioRepository(_db);
        Tarea = new TareaRepository(_db);
    }
    public IUsuarioRepository Usuario { get; private set; }

    public ITareaRepository Tarea { get; private set; }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await _db.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        await _db.Database.CommitTransactionAsync();
    }

    public async Task RollbackAsync()
    {
        await _db.Database.RollbackTransactionAsync();
    }

    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }

    public async ValueTask DisposeAsync()
    {
        await _db.DisposeAsync();
    }
}

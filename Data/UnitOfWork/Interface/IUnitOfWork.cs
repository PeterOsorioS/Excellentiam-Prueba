using Excellentiam.Data.Repository.Interface;
using Excellentiam.Migrations;
using Microsoft.EntityFrameworkCore.Storage;

namespace Excellentiam.Data.UnitOfWork.Interface;

public interface IUnitOfWork : IAsyncDisposable
{
    public IUsuarioRepository Usuario { get; }
    public ITareaRepository Tarea { get; }

    Task<IDbContextTransaction> BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
    Task SaveAsync();
    ValueTask DisposeAsync();
}

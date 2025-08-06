using Excellentiam.Models;
using Microsoft.EntityFrameworkCore;

namespace Excellentiam.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options): base(options)
    {      
    }
    public DbSet<Tarea> Tareas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
}

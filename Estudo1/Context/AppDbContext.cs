using Estudo1.Models;
using Microsoft.EntityFrameworkCore;

namespace Estudo1.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TarefaModel> Tarefa { get; set; }
    }
}
    
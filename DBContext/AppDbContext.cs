using MicroServicioCP.Entidades.Context;
using Microsoft.EntityFrameworkCore;

namespace MicroServicioCP.DBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<ClienteContext> Cliente { get; set; }
        
    }
}

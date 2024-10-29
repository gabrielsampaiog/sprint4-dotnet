using Microsoft.EntityFrameworkCore;
using TAQUI.Model;

namespace TAQUI.Database
{
    public class FIAPMongoDBContext(DbContextOptions<FIAPMongoDBContext> options) : DbContext(options)
    {
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}

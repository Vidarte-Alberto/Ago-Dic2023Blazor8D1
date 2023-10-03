using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace LasPollasHermanas.Server.Models
{
    public class DildoStoreContext : DbContext
    {
        public DbSet<Dildo> Dildos => Set<Dildo>();
        public DildoStoreContext(DbContextOptions<DildoStoreContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace LasPollasHermanas.Server.Models
{
    public class DildoStoreContext : DbContext
    {
        public DbSet<Dildo> Dildos => Set<Dildo>();
        public DildoStoreContext(DbContextOptions<DildoStoreContext> options) : base(options)
        {
        }
    }
}

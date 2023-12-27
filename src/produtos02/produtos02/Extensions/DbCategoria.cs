using Microsoft.EntityFrameworkCore;

namespace produtos02.Extensions
{
    public class DbCategoria : DbContext
    {
        public DbCategoria(DbContextOptions<DbProduto> Options) : base(Options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<>;

    }
}

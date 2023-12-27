using Microsoft.EntityFrameworkCore;

namespace produtos02.Extensions
{
    public class DbProduto : DbContext
    {
        public DbProduto(DbContextOptions<DbProduto> Options) : base(Options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new produto)
        }





        public DbSet<>;








        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new VeiculoConfiguration());
        //    modelBuilder.ApplyConfiguration(new FabricanteConfiguration());
        //}
    }
}

using Microsoft.EntityFrameworkCore;
using produtos02.Data.Configurations;

namespace produtos02.Data.Entities
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
            modelBuilder.ApplyConfiguration(new ProdutoConfigurations());
            modelBuilder.ApplyConfiguration(new CategoriaConfigurations());
        }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }


    }
}

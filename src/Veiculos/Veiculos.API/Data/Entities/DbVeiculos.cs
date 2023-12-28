using Microsoft.EntityFrameworkCore;
using Veiculos.API.Data.Configurations;

namespace Veiculos.API.Data.Entities
{
    public class DbVeiculos : DbContext
    {

        public DbVeiculos(DbContextOptions<DbVeiculos> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VeiculoConfiguration());
            modelBuilder.ApplyConfiguration(new FabricanteConfiguration());
        }

        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }

    }
}

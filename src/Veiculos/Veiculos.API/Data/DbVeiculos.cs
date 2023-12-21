using Microsoft.EntityFrameworkCore;
using Veiculos.API.Data.Configurations;
using Veiculos.API.Data.Entities;

namespace Veiculos.API.Data
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

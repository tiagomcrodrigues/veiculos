using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using Veiculos.API.Data.Configurations;

namespace Veiculos.API.Data
{
    public class DbVeiculos : DbContext
    {

        public DbVeiculos(DbContextOptions<DbVeiculos> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VeiculoConfiguration());
        }

        public DbSet<Veiculo> Veiculos { get; set; } 

    }
}

using Livraria.Data.Configuarations;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Data.Entities
{
    public class DbLivraria : DbContext
    {
        public DbLivraria(DbContextOptions<DbLivraria> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AutoresConfigurations());
            modelBuilder.ApplyConfiguration(new LivrosConfigurations());
            modelBuilder.ApplyConfiguration(new PessoasConfigurations());
        }


        public DbSet<Autores> Autores { get; set; }

        public DbSet<Livros> Livros { get; set; }

        public DbSet<Pessoas> Pessoas { get ; set; }
    }
}

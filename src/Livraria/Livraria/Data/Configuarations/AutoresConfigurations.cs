using Livraria.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Livraria.Data.Configuarations
{
    public class AutoresConfigurations : IEntityTypeConfiguration<Autores>
    {
        public void Configure(EntityTypeBuilder<Autores> b)
        {
            b.ToTable("Autores");

            b.HasKey(nameof(Autores.Id));

            b.Property(nameof(Autores.Id))
                .ValueGeneratedOnAdd();

            b.Property(b => b.Nome)
                .HasColumnName(nameof(Autores.Nome))
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();

            b.HasIndex(Autores => Autores.Nome)
                .HasDatabaseName($"UK_{nameof(Autores)}_{nameof(Autores.Nome)}")
                .IsUnique();
            
        }
    }
}

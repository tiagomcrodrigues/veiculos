using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veiculos.API.Data.Entities;

namespace Veiculos.API.Data.Configurations
{
    public class FabricanteConfiguration : IEntityTypeConfiguration<Fabricante>
    {
        public void Configure(EntityTypeBuilder<Fabricante> b)
        {

            b.ToTable("fabricante");
            b.HasKey(fabricante => fabricante.Id);

            b.Property(c => c.Nome)
                .HasColumnName(nameof(Fabricante.Nome))
                 .HasMaxLength(50)
                 .IsUnicode(false);

            b.HasIndex(fabricante => fabricante.Nome)
                .HasDatabaseName($"UK_{nameof(Fabricante)}_{nameof(Fabricante.Nome)}")
                .IsUnique();

        }
    }
}

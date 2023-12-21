using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Veiculos.API.Data.Entities;

namespace Veiculos.API.Data.Configurations
{
    public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> b)
        {

            b.ToTable("veiculo");
            b.HasKey(veiculo =>  veiculo.Id);

            b.Property(c => c.AnoModelo)
                .HasColumnName(nameof(Veiculo.AnoModelo))
                .HasColumnType("smallint")
                .IsRequired();

            b.Property(c => c.AnoFabricacao)
                .HasColumnName(nameof(Veiculo.AnoFabricacao))
                .HasColumnType("smallint")
                .IsRequired();


            b.Property(c => c.Modelo)
               .HasColumnName(nameof(Veiculo.Modelo))
                .HasMaxLength(50)
                .IsUnicode(false);

            b.Property(c => c.FabricanteId)
                .HasColumnName(nameof(Veiculo.FabricanteId));
                 

            b.Property(c => c.Cor)
               .HasColumnName(nameof(Veiculo.Cor))
                .HasMaxLength(50)
                .IsUnicode(false);

            b.Property(c => c.Placa)
               .HasColumnName(nameof(Veiculo.Placa))
                .HasMaxLength(7)
                .IsUnicode(false);


            b.Property(c => c.Tipo)
               .HasColumnName(nameof(Veiculo.Tipo))
                .HasMaxLength(20)
                .IsUnicode(false);

            b.HasOne(o => o.Fabricante)
                .WithMany(d => d.Veiculos)
                .HasForeignKey(fk => fk.FabricanteId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}

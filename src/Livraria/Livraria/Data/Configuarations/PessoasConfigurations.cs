using Livraria.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Livraria.Data.Configuarations
{
    public class PessoasConfigurations : IEntityTypeConfiguration<Pessoas>
    {
        public void Configure(EntityTypeBuilder<Pessoas> b)
        {
            b.ToTable(nameof(Pessoas));

            b.HasKey(nameof(Pessoas.Id));

            b.Property(nameof(Pessoas.Id))
                .ValueGeneratedOnAdd();

            b.Property(b => b.Nome)
                .HasColumnName(nameof(Pessoas.Nome))
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();

            b.Property(b => b.Cpf)
                .HasColumnName(nameof (Pessoas.Cpf))
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsRequired();

            b.Property(b => b.Cep)
                .HasColumnName(nameof(Pessoas.Cep))
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsRequired();


            b.Property(b => b.Numero)
                .HasColumnName(nameof(Pessoas.Numero))
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsRequired();

            b.Property(b => b.Complemento)
                .HasColumnName(nameof(Pessoas.Complemento))
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            b.Property(b => b.Telefone)
                .HasColumnName(nameof(Pessoas.Telefone))
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired();

            b.HasIndex(Pessoas => Pessoas.Nome)
                .HasDatabaseName($"Uk_{nameof(Pessoas)}_{nameof(Pessoas.Nome)}")
                .IsUnique();

            b.HasIndex(Pessoas => Pessoas.Cpf)
                .HasDatabaseName($"Uk_{nameof(Pessoas)}_{nameof(Pessoas.Cpf)}")
                .IsUnique();

        }
    }
}

using Livraria.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Livraria.Data.Configuarations
{
    public class LivrosConfigurations : IEntityTypeConfiguration<Livros>
    {
        public void Configure(EntityTypeBuilder<Livros> b)
        {
            b.ToTable(nameof(Livros));

            b.HasKey(nameof(Livros.Id));

            b.Property(nameof(Livros.Id))
                .ValueGeneratedOnAdd();

            b.Property(b => b.Titulo)
                .HasColumnName(nameof(Livros.Titulo))
                .HasMaxLength(80)
                .IsUnicode(false)
                .IsRequired();

            b.Property(b => b.Descricao)
                .HasColumnName(nameof(Livros.Descricao))
                .HasMaxLength(500)
                .IsUnicode(false)
                .IsRequired();

            b.Property(b => b.AutorId)
                .HasColumnName(nameof(Livros.AutorId))
                .IsRequired();

            b.Property(b => b.Quantidade)
                .HasColumnName(nameof(Livros.Quantidade))
                .IsRequired();

            b.Property(b => b.PermitirEmprestimo)
                .HasColumnName(nameof(Livros.PermitirEmprestimo))
                .HasColumnType("bit")
                .HasDefaultValue(false)
                .IsRequired();

            b.HasIndex(Livros => Livros.Titulo)
                .HasDatabaseName($"UK_{nameof(Livros)}_{nameof(Livros.Titulo)}")
                .IsUnique();

            b.HasOne(o => o.Autor)
                .WithMany(d => d.Livros)
                .HasForeignKey(fk => fk.AutorId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
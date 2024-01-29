using Livraria.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Livraria.Data.Configuarations
{
    public class EmprestimosConfigurations : IEntityTypeConfiguration<Emprestimos>
    {
        public void Configure(EntityTypeBuilder<Emprestimos> b)
        {
            b.ToTable(nameof(Emprestimos));

            b.HasKey(nameof(Emprestimos.Id));
            b.Property(nameof(Emprestimos.Id))
                .ValueGeneratedOnAdd();

            b.Property(b => b.PessoaId)
                .HasColumnName(nameof(Emprestimos.PessoaId))
                .IsUnicode(false)
                .IsRequired();

            b.Property(b => b.LivroId)
                .HasColumnName(nameof(Emprestimos.LivroId))
                .IsUnicode(false)
                .IsRequired();

            b.Property(b => b.DataEprestimo)
                .HasColumnName(nameof(Emprestimos.DataEprestimo))
                .IsUnicode(false)
                .IsRequired();

            b.Property(b => b.DataVencimeto)
                .HasColumnName(nameof(Emprestimos.DataVencimeto))
                .IsUnicode(false)
                .IsRequired();

            b.Property(b => b.DataDevolucao)
                .HasColumnName(nameof(Emprestimos.DataDevolucao))
                .IsUnicode(false)
                .IsRequired();

             b.HasOne(o => o.Pessoas)
                .WithMany(d => d.Emprestimos)
                .HasForeignKey(fk => fk.PessoaId)
                .OnDelete(DeleteBehavior.Restrict);

            b.HasOne(o => o.Livros)
                .WithMany(d => d.Emprestimos)
                .HasForeignKey(fk => fk.LivroId)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }
}

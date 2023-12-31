using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using produtos02.Data.Entities;

namespace produtos02.Data.Configurations
{
    public class ProdutoConfigurations : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> b)// b = builder
        {
            b.ToTable("produto");//definido que e tabela com o nome produto
            //difinido que Id e (chave primaria = HasKey)
            b.HasKey(Produto => Produto.Id);

            //definido os otros campos 

            b.Property(b => b.Nome)///definido propriedade
                .HasColumnName(nameof(Produto.Nome))//definido nome
                .HasMaxLength(80)//definido o maximo de caracteres
                .IsUnicode(false)
                .IsRequired();

            b.Property(b => b.Descricao)///definido propriedade
                .HasColumnName(nameof(Produto.Descricao))//definido nome
                .HasMaxLength(2000)//definido o maximo de caracteres
                .IsUnicode(false)
                .IsRequired();

            b.Property(b => b.CategoriaId)///definido propriedade
                .HasColumnName(nameof(Produto.CategoriaId))//definido nome
                .IsRequired();

            b.Property(b => b.Ativo)
                .HasColumnName(nameof(Categoria.Ativo))
                .HasColumnType("bit")
                .HasDefaultValue(false)
                .IsRequired();

            b.HasIndex(produto => produto.Nome)
                .HasDatabaseName($"UK_{nameof(Produto)}_{nameof(Produto.Nome)}")
                .IsUnique();


            b.HasOne(o => o.Categoria)
                .WithMany(d => d.Produtos)
                .HasForeignKey(fk => fk.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}

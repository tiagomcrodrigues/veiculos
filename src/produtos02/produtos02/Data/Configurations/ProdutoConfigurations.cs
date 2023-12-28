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

            b.Property(b => b.nome)///definido propriedade
                .HasColumnName(nameof(Produto.nome))//definido nome
                .HasMaxLength(80)//definido o maximo de caracteres
                .IsUnicode(false);

            b.Property(b => b.Descricao)///definido propriedade
                .HasColumnName(nameof(Produto.Descricao))//definido nome
                .HasMaxLength(80)//definido o maximo de caracteres
                .IsUnicode(false);

            b.Property(b => b.CategoriaId)///definido propriedade
                .HasColumnName(nameof(Produto.CategoriaId));//definido nome

            b.Property(b => b.Ativo)
                .HasColumnName(nameof(Categoria.Ativo))
                .HasColumnType("bit")
                .HasDefaultValue(false)
                .IsRequired();



        }
    }
}

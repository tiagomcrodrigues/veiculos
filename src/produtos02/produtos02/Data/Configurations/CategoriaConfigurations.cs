using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using produtos02.Data.Entities;

namespace produtos02.Data.Configurations
{
    public class CategoriaConfigurations : IEntityTypeConfiguration<Categoria>
    {

        public void Configure(EntityTypeBuilder<Categoria> b)// b = builder
        {
            b.ToTable("categoria");
            //difinido que Id e (chave primaria = HasKey)
            b.HasKey(Categoria => Categoria.Id);
            //definido os otros campos 

            b.Property(b => b.Descricao)
                .HasColumnName(nameof(Categoria.Descricao))
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();

            b.Property(b => b.Ativo)
                .HasColumnName(nameof(Categoria.Ativo))
                .HasColumnType("bit")
                .HasDefaultValue(false)
                .IsRequired();


            b.HasIndex(categoria => categoria.Descricao)
                .HasDatabaseName($"UK_{nameof(Categoria)}_{nameof(Categoria.Descricao)}")
                .IsUnique();


        }
    }
}

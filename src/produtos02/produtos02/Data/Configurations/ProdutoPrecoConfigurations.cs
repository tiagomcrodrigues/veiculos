using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using produtos02.Data.Entities;

namespace produtos02.Data.Configurations
{
    public class ProdutoPrecoConfigurations : IEntityTypeConfiguration<ProdutoPreco>
    {
        public void Configure(EntityTypeBuilder<ProdutoPreco> b)
        {
            b.ToTable(nameof(ProdutoPreco));

            b.HasKey(b => b.Id);
             
               
            b.Property(b => b.DataCadastro)
                .HasColumnName(nameof(ProdutoPreco.DataCadastro))
                .IsRequired();

            b.Property(b => b.Valor)
                .HasColumnName(nameof (ProdutoPreco.Valor))
                .HasColumnType("decimal(16,2)")
                .IsRequired();

            b.HasOne(o => o.Produto)
                .WithMany(d => d.ProdutoPreco)
                .HasForeignKey(o => o.ProdutoId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}

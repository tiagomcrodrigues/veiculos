using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using produtos02.Data.Entities;

namespace produtos02.Data.Configurations
{
    public class EstoqueConfigurations : IEntityTypeConfiguration<Estoque>
    {
        public void Configure(EntityTypeBuilder<Estoque> b) 
        {        
            
            b.ToTable(nameof(Estoque));//nome tabela 


            b.HasKey(b => b.ProdutoId);
                
            b.Property(b => b.Quantidade)
                .HasColumnName(nameof(Estoque.Quantidade))
                .HasColumnType("decimal(16,3)")
                .IsRequired();

            b.Property(b => b.CustoMedio)
                .HasColumnName(nameof(Estoque.CustoMedio))
                .HasColumnType("decimal(16,2)")
                .IsRequired();

            b.HasOne(o => o.Produto)
                .WithOne(d => d.Estoque)
                .HasForeignKey<Estoque>(fk => fk.ProdutoId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}

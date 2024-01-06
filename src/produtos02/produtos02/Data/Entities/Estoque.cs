namespace produtos02.Data.Entities
{
    public class Estoque
    { 
        public Guid ProdutoId { get; set; }
        public decimal Quantidade { get; set;}
        public decimal CustoMedio { get; set; }

        public virtual Produto Produto { get; set; }
    }
}

namespace produtos02.Data.Entities
{
    public class Estoque
    { 
        public Guid ProdutoId { get; set; }
        public double Quantidade { get; set;}
        public double CustoMedio { get; set; }

        public virtual Produto Produto { get; set; }
    }
}

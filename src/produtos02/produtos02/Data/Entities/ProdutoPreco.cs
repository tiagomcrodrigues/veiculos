namespace produtos02.Data.Entities
{
    public class ProdutoPreco
    {

        public Guid Id { get; set; }
        public Guid ProdutoId { get; set; }
        public DateTime DataCadastro { get; set; }
        public decimal Valor { get; set; }

        public virtual Produto Produto { get; set; }
    }
}

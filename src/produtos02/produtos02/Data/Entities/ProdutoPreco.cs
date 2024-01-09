namespace produtos02.Data.Entities
{
    public class ProdutoPreco
    {

        public ProdutoPreco()
        {
            Id = Guid.NewGuid();
        }

        public ProdutoPreco(Guid produtoId,double valor):this()
        {
            ProdutoId = produtoId;
            Valor = valor;

        }


        public Guid Id { get; set; }
        public Guid ProdutoId { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public double Valor { get; set; }

        public virtual Produto Produto { get; set; }
    }
}

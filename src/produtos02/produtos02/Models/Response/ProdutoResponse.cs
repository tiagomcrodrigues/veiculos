namespace produtos02.Models.Response
{
    public class ProdutoResponse
    {

        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public double Quantidade { get; set; }
        public double CustoMedio { get; set; }
        public Double preco { get; set; }
        public CategoriaProdutoResponse? Categoria { get; set; }
        public bool Ativo { get; set; }

    }

}

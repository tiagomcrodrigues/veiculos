namespace produtos02.Models.Request
{
    public class ProdutoRequest
    {
        public string? Descricao { get; set; }
        public int CategoriaId { get; set; }
        public bool Ativo { get; set; }
    }
}

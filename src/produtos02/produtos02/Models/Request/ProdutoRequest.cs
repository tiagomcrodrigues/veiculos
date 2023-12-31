namespace produtos02.Models.Request
{
    public class ProdutoRequest
    {
        public string? nome { get; set; }
        public string? Descricao { get; set; }
        public Guid CategoriaId { get; set; }
        public bool Ativo { get; set; }
    }
}

namespace produtos02.Models.Responce
{
    public class ProdutoResponse
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public Guid CategoriaId { get; set; }
        public bool Ativo { get; set; }

    }
}

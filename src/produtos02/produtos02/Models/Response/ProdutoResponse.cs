namespace produtos02.Models.Responce
{
    public class ProdutoResponse
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public int CategoriaId { get; set; }
        public bool Ativo { get; set; }

    }
}

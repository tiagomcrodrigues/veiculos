namespace Livraria.Models.Response
{
    public class LivrosResponse
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int AutorId { get; set; }
        public int Quantidade { get; set; }
        public bool PremitirEmprestimo { get; set; }

    }
}

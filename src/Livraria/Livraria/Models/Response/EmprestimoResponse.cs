namespace Livraria.Models.Response
{
    public class EmprestimoResponse
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public int LivroId { get; set; }
        public DateTime DataEprestimo { get; set; } 
        public DateTime DataVencimeto { get; set; } 
        public DateTime? DataDevolucao { get; set; }
    }
}

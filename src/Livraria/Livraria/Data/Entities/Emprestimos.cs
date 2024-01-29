namespace Livraria.Data.Entities
{
    public class Emprestimos
    {
        public Emprestimos()
        {
        }

        public Emprestimos(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        public int PessoaId { get; set; }
        public int LivroId { get; set; }
        public DateTime DataEprestimo { get; set; } = DateTime.Now;
        public DateTime DataVencimeto { get; set; } = DateTime.Now.AddDays(+15);
        public DateTime? DataDevolucao { get; set; }

        public virtual Pessoas Pessoas { get; set; }
        public virtual Livros Livros { get; set; }

    }
}

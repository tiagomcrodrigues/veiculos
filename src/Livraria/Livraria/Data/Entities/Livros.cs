namespace Livraria.Data.Entities
{
    public class Livros
    {


        public Livros(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int AutorId { get; set; }
        public int Quantidade { get; set; }
        public int QuantidadeEmprestimo { get; set; }
        public bool PrmitirEmprestimo { get; set; }

        public virtual Autores Autores { get; set; }
        //public virtual ICollection<Emprestimos> Emprestadores { get; set; }
    }
}

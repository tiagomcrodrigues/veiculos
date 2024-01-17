namespace Livraria.Data.Entities
{
    public class Livros
    {
        public Livros() { }

        public Livros(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int AutorId { get; set; }
        public int Quantidade { get; set; }
        public bool PermitirEmprestimo { get; set; }

        public virtual Autores Autor { get; set; }
        //public virtual ICollection<Emprestimos> Emprestimos { get; set; }
    }
}

namespace Livraria.Data.Entities
{
    public class Autores
    {

        public Autores() { }

        public Autores(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

        public string Nome{ get; set; }

        //public virtual ICollection<Livros> Livros { get; set; }
    }
}

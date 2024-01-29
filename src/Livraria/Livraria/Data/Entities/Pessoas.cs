
namespace Livraria.Data.Entities
{
    public class Pessoas
    {
        public Pessoas(){}

        public Pessoas(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Cep { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Telefone { get; set; }

         public virtual  ICollection<Emprestimos> Emprestimos { get; set; }
    }
}

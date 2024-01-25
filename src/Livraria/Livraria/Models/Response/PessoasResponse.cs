using System.ComponentModel.DataAnnotations;

namespace Livraria.Models.Response
{
    public class PessoasResponse
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int Cpf { get; set; }

        public int Cep { get; set; }

        public int Numero { get; set; }

        public string Complemento { get; set; }

        public int Telefone { get; set; }
    }
}

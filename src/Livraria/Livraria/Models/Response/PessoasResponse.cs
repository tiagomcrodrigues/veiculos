using System.ComponentModel.DataAnnotations;

namespace Livraria.Models.Response
{
    public class PessoasResponse
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Cep { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Telefone { get; set; }
    }
}

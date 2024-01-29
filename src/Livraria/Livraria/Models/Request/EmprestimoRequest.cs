using System.ComponentModel.DataAnnotations;

namespace Livraria.Models.Request
{
    public class EmprestimoRequest
    {

        [Required(ErrorMessage = "o campo Pessoa Id e obrigatorio")]
        public int PessoaId { get; set; }

        [Required(ErrorMessage = "o campo Livro Id e obrigatorio")]
        public int LivroId { get; set; }


    }
}

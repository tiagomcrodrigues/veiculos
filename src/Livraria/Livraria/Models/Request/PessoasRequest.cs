using System.ComponentModel.DataAnnotations;

namespace Livraria.Models.Request
{
    public class PessoasRequest
    {
        
        [Required(ErrorMessage = "O canpo Cpf é obrigattório")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O canpo nome é obrigattório")]
        [StringLength(100, ErrorMessage = "O campo nome deve conter no máximo 100 Caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O canpo nome é obrigattório")]
        [StringLength(8, ErrorMessage = "O campo Cep deve conter no máximo 8 Caracteres")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O canpo numero é obrigattório")]
        [StringLength(10, ErrorMessage = "O campo numero deve conter no máximo 10 Caracteres")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "O canpo Complemento é obrigattório")]
        [StringLength(50, ErrorMessage = "O campo complemento deve conter no máximo 50 Caracteres")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "O canpo telefone é obrigattório")]
        [StringLength(20, ErrorMessage = "O campo telefone deve conter no máximo 20 Caracteres")]
        public string Telefone { get; set; }
    }
}

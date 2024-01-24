using System.ComponentModel.DataAnnotations;

namespace Livraria.Models.Request
{
    public class LivrosRequest
    {
        [Required(ErrorMessage = "Campo Titulo é obrigatório")]
        [StringLength(80, ErrorMessage = "O campo deve conter no máximo 80 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Campo Descrição é obrigatório")]
        [StringLength(500, ErrorMessage = "O campo deve conter no máximo 500 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "o campo autor Id e obrigatorio")]
        public int AutorId { get; set; }

        [Required(ErrorMessage = "o campo quantidade e obrigatorio")]
        [Range(1, 999, ErrorMessage = $"A quantidade deve ser informado (valores entre 1 e 999)")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O canpo permitir emprestimo e obrigatorio")]
        public bool PremitirEmprestimo { get; set; }

    }
}

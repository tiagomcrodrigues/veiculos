using System.ComponentModel.DataAnnotations;

namespace Livraria.Models.Request
{
    public class AutoresRequest
    {
        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo deve conter no máximo 50 caracteres")]
        public string? Nome { get; set; }


    }
}

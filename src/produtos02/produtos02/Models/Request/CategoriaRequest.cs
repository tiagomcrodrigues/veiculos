using System.ComponentModel.DataAnnotations;

namespace produtos02.Models.Request
{
    public class CategoriaRequest
    {
        [Required(ErrorMessage = "o campo descrição e obrigatorio")]
        [StringLength(100, ErrorMessage = "o campo deve conter no máximo 80 caracteres")]
        public string? Descricao { get; set; }
       
        public bool Ativo { get; set; }
    }
}       

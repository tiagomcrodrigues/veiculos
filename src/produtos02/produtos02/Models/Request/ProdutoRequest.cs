using System.ComponentModel.DataAnnotations;

namespace produtos02.Models.Request
{
    public class ProdutoRequest
    {
        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        [StringLength(80, ErrorMessage = "O campo deve conter no máximo 50 caracteres")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Campo Descrição é obrigatório")]
        [StringLength(2000, ErrorMessage = "O campo deve conter no máximo 50 caracteres")]
        public string? Descricao { get; set; }

        
        public Guid CategoriaId { get; set; }
        
        public bool Ativo { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace produtos02.Models.Request
{
    public class ProdutoPrecoRequest
    {

        [Required(ErrorMessage = "Campo Produto Id é obrigatório")]
        public Guid ProdutoId { get; set; }

        public DateOnly DataCadastro { get; set; }

        [Required(ErrorMessage = "Campo valor é obrigatório")]
        public decimal valor { get; set; }

    }
}

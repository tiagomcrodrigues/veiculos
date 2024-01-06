using System.ComponentModel.DataAnnotations;

namespace produtos02.Models.Request
{
    public class EstoqueRequest
    {
        [Required(ErrorMessage = "Campo Produto Id é obrigatório")]
        public Guid ProdutoId { get; set; }

        [Required(ErrorMessage = "A quantrdade é obrigatório")]
        public decimal Quantidade { get; set; }

        public decimal CustoMedio { get; set; }

    }
}

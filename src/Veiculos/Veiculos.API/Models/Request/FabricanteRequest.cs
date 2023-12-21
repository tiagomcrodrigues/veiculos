using System.ComponentModel.DataAnnotations;

namespace Veiculos.API.Models.Request
{
    public class FabricanteRequest
    {

        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo deve conter no máximo 50 caracteres")]
        public string? Nome { get; set; }

    }
}

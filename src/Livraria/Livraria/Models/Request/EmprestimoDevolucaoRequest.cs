using System.ComponentModel.DataAnnotations;

namespace Livraria.Models.Request
{
    public class EmprestimoDevolucaoRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="O campo data de devolução e obrigatorio")]
        public DateTime DataDevolucao { get; set;}

    }
}

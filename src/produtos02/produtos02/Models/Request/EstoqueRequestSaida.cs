using System.ComponentModel.DataAnnotations;

namespace produtos02.Models.Request
{
    public class EstoqueRequestSaida
    {

        [Required(ErrorMessage = "A quantrdade é obrigatório")]
        [Range(0.01, 9999999999999.999, ErrorMessage = $"O custo deve ser informado (valores entre 0,01 e 9.999.999.999.999,999)")]
        public double Quantidade { get; set; }


    }
}

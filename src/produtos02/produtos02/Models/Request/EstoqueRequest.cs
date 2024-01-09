using System.ComponentModel.DataAnnotations;

namespace produtos02.Models.Request
{
    public class EstoqueRequest
    {

        [Range(0.01, 9999999999999.999, ErrorMessage = $"A quantidade deve ser informada (valores entre 0,01 e 9.999.999.999.999,999)")]
        public double Quantidade { get; set; }

        [Range(0.01, 99999999999999.99, ErrorMessage = $"O valor deve ser informado (valores entre 0,01 e 99.999.999.999.999,99)")]
        public double Valor { get; set; }

    }
}

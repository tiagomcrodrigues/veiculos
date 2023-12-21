using System.ComponentModel.DataAnnotations;

namespace Veiculos.API.Models.Request
{
    public class VeiculoRequest
    {
        [Required(ErrorMessage ="Campo Ano modelo é obrigatório")]
        [Range(1000,2025,ErrorMessage ="Este ano e invalido")]
        public short? AnoModelo { get; set; }

        [Range(1900, 2025, ErrorMessage = "Este ano e invalido")]
        [Required(ErrorMessage = "Campo ano fabricação é obrigatório")]
        public short? AnoFabricacao { get; set; }

        [Required(ErrorMessage = "Campo modelo é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo deve conter no máximo 50 caracteres")]
        public string? Modelo { get; set; }
        
        [Required(ErrorMessage = "Campo fabricante é obrigatório")]
        public Guid? FabricanteId { get; set; }
        
        [StringLength(50, ErrorMessage = "O campo deve conter no máximo 50 caracteres")]
        public string? Cor { get; set; }
        [StringLength(7, ErrorMessage = "O campo deve conter no máximo 50 caracteres")]
        public string? Placa { get; set; }
        [StringLength(50, ErrorMessage = "O campo deve conter no máximo 50 caracteres")]
        public string? Tipo { get; set; }

    }
}

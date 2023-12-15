﻿using System.ComponentModel.DataAnnotations;

namespace Veiculos.API.Models.Request
{
    public class VeiculoRequest
    {
        [Required(ErrorMessage ="Campo Ano modelo é obrigatório")]
        [Range(1900,2025,ErrorMessage ="Este ano e invalido")]
        public short? AnoModelo { get; set; }

        [Range(1900, 2025, ErrorMessage = "Este ano e invalido")]
        [Required(ErrorMessage = "Campo ano fabricação é obrigatório")]
        public short? AnoFabricacao { get; set; }

        [Required(ErrorMessage = "Campo modelo é obrigatório")]
        public string? Modelo { get; set; }
        
        [Required(ErrorMessage = "Campo fabricante é obrigatório")]
        public string? Fabricante { get; set; }
        
        public string? Cor { get; set; }
        
        public string? Placa { get; set; }
        
        public string? Tipo { get; set; }

    }
}

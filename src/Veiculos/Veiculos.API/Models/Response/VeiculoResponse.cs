using System.ComponentModel.DataAnnotations;
using Veiculos.API.Models.Request;

namespace Veiculos.API.Models.Response
{
    public class VeiculoResponse 
    {


        public Guid Id { get; set; }

        public short? AnoModelo { get; set; }

        public short? AnoFabricacao { get; set; }

        public string? Modelo { get; set; }

        public VeiculoFabricanteResponse Fabricante { get; set; }

        public string? Cor { get; set; }

        public string? Placa { get; set; }

        public string? Tipo { get; set; }

    }

    public class VeiculoFabricanteResponse
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }
    }

}

using Veiculos.API.Data.Entities;
using Veiculos.API.Models.Request;
using Veiculos.API.Models.Response;

namespace Veiculos.API.Extensions
{
    public static class VeiculoExtension
    {

        public static Veiculo Map(this VeiculoRequest request)
        {

            Veiculo veiculo = new()
            {
                AnoModelo = request.AnoModelo ?? default,
                AnoFabricacao = request.AnoFabricacao ?? default,
                Modelo = request.Modelo ?? string.Empty,
                FabricanteId = request.FabricanteId.Value,
                Cor = request.Cor,
                Placa = request.Placa,
                Tipo = request.Tipo
            };

            return veiculo;

        }

        public static VeiculoResponse Map(this Veiculo veiculo)
        {

            var resp = new VeiculoResponse()
            {
                Id = veiculo.Id,
                AnoModelo = veiculo.AnoModelo,
                AnoFabricacao = veiculo.AnoFabricacao,
                Modelo = veiculo.Modelo,
                Fabricante = new()
                {
                    Id = veiculo.FabricanteId,
                    Nome = veiculo.Fabricante.Nome
                },
                Cor = veiculo.Cor,
                Placa = veiculo.Placa,
                Tipo = veiculo.Tipo
            };

            return resp;

        }


    }
}

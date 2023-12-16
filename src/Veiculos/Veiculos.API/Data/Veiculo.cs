using System.ComponentModel.DataAnnotations;

namespace Veiculos.API.Data
{
    public class Veiculo
    {

        public Veiculo()
        {
            Id = Guid.NewGuid();
        }

        public Veiculo(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        public short AnoModelo { get; set; }

        public short AnoFabricacao { get; set; }

        public string Modelo { get; set; }

        public string? Fabricante { get; set; }

        public string? Cor { get; set; }

        public string? Placa { get; set; }

        public string? Tipo { get; set; }

    }
}

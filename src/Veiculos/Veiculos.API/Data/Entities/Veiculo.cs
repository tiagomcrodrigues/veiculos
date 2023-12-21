using System.ComponentModel.DataAnnotations;

namespace Veiculos.API.Data.Entities
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

        public Guid FabricanteId { get; set; }
        
        public string? Cor { get; set; }

        public string? Placa { get; set; }

        public string? Tipo { get; set; }

        public virtual Fabricante Fabricante { get; set; }

    }
}

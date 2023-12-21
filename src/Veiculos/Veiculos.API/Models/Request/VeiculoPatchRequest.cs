namespace Veiculos.API.Models.Request
{
    public class VeiculoPatchRequest
    {
        public short? AnoModelo { get; set; }

        public short? AnoFabricacao { get; set; }

        public string? Modelo { get; set; }
        
        public Guid? FabricanteId { get; set; }
        
        public string? Cor { get; set; }
        
        public string? Placa { get; set; }
        
        public string? Tipo { get; set; }

    }
}

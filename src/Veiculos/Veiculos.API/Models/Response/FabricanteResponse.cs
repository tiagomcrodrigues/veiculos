using Veiculos.API.Models.Request;

namespace Veiculos.API.Models.Response
{
    public  class FabricanteResponse : FabricanteRequest
    {
        public Guid Id { get; set; }    
    }
}

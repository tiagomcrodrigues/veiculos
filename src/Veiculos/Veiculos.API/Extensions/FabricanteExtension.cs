using Veiculos.API.Data;
using Veiculos.API.Data.Entities;
using Veiculos.API.Models.Request;
using Veiculos.API.Models.Response;

namespace Veiculos.API.Extensions
{
    public static class FabricanteExtension
    {
        public static Fabricante Map(this FabricanteRequest fabricante)
        {

            var resp = new Fabricante()
            {
                Nome = (fabricante.Nome ?? string.Empty).ToUpper()
            };

            return resp;

        } 

        public static FabricanteResponse Map(this Fabricante fabricante)
        {

            var resp = new FabricanteResponse()
            {
                Id = fabricante.Id,
                Nome = fabricante.Nome
            };

            return resp;

        }

    }
}

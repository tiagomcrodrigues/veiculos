using System.Net.NetworkInformation;

namespace Veiculos.API.Data
{
    public class DbContext
    {

        private static readonly IList<Veiculo> _veiculos = new List<Veiculo>();

        public IList<Veiculo> Veiculos => _veiculos;


    }
}

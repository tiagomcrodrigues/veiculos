using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Veiculos.API.Data.Entities;

namespace Veiculos.API.Data
{
    public class Fabricante
    {

        public Fabricante()
        {
            Id = Guid.NewGuid();
        }

        public Fabricante(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        public string Nome { get; set; }

        public virtual ICollection<Veiculo> Veiculos  { get; set; }


    }
}

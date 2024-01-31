using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TesteQuebraTudo
{
    public class CepResponse
    {
        //public string Cep { get; set; }
        //public string Logradouro { get; set; }
        //public string Numero { get; set; }
        //public string Complemento { get; set; }
        //public string Bairro { get; set; }
        //[JsonPropertyName("localidade")]
        //public string Cidade { get; set; }
        //public string Uf { get; set; }

        public string Cep { get; set; }
        public string TipoLogradouro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }


    }

}

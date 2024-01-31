using System.Text.Json;
using TesteQuebraTudo;

namespace Livraria.Tools
{
    public static class Ferramentas
    {

        public static async Task<CepResponse> BuscaCep(string cep)
        {

            //string uri = $"https://viacep.com.br/ws/{cep}/json";
            string uri = $"http://192.168.3.1:5010/endereco/cep/{cep}";

            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(uri),

            };

            HttpClient client = new();
            HttpResponseMessage response = await client.SendAsync(request);

            string body = await response.Content.ReadAsStringAsync();
            CepResponse? dadosCep =
                JsonSerializer.Deserialize<CepResponse>(
                    body,
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                );

            return dadosCep;

        }

    }
}

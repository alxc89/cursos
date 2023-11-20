using Paralelismo.Models;
using System.Text.Json;

namespace Paralelismo;

public class ViaCepService
{
    public CepModel GetCep(string cep)
    {
        var client = new HttpClient();
        var response = client.GetAsync($"https://viacep.com.br/ws/{cep}/json/").Result;
        var content = response.Content.ReadAsStringAsync().Result;
        var cepResult = JsonSerializer.Deserialize<CepModel>(content);
        if (cepResult == null)
            return null!;
        return cepResult;
    }
}

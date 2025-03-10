using MeuProjetoMVC.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MeuProjetoMVC.Services
{
    public class ClienteService
    {
        private readonly HttpClient _httpClient;
        private const string apiUrl = "https://camposdealer.dev/Sites/TesteAPI/cliente";

        public ClienteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Cliente>> ObterProdutosAsync()
        {
            var resposta = await _httpClient.GetStringAsync(apiUrl);
            return JsonSerializer.Deserialize<List<Cliente>>(resposta, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}

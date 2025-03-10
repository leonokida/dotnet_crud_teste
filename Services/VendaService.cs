using MeuProjetoMVC.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MeuProjetoMVC.Services
{
    public class VendaService
    {
        private readonly HttpClient _httpClient;
        private const string apiUrl = "https://camposdealer.dev/Sites/TesteAPI/venda";

        public VendaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Venda>> ObterProdutosAsync()
        {
            var resposta = await _httpClient.GetStringAsync(apiUrl);
            return JsonSerializer.Deserialize<List<Venda>>(resposta, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}

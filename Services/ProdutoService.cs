using MeuProjetoMVC.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MeuProjetoMVC.Services
{
    public class ProdutoService
    {
        private readonly HttpClient _httpClient;
        private const string apiUrl = "https://camposdealer.dev/Sites/TesteAPI/produto";

        public ProdutoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Produto>> ObterProdutosAsync()
        {
            var resposta = await _httpClient.GetStringAsync(apiUrl);
            return JsonSerializer.Deserialize<List<Produto>>(resposta, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}

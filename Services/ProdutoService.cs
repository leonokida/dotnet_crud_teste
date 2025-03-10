using MeuProjetoMVC.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
            return JsonConvert.DeserializeObject<List<Produto>>(JsonConvert.DeserializeObject<string>(resposta));
        }
    }
}

using MeuProjetoMVC.Models;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
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

        public async Task<List<Venda>> ObterVendasAsync()
        {
            var resposta = await _httpClient.GetStringAsync(apiUrl);
            return JsonConvert.DeserializeObject<List<Venda>>(JsonConvert.DeserializeObject<string>(resposta));
        }
    }
}

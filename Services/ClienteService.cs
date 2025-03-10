using MeuProjetoMVC.Models;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
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

        public async Task<List<Cliente>> ObterClientesAsync()
        {
            var resposta = await _httpClient.GetStringAsync(apiUrl);
            return JsonConvert.DeserializeObject<List<Cliente>>(JsonConvert.DeserializeObject<string>(resposta));
        }
    }
}

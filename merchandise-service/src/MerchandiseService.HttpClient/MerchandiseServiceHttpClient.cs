using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.HttpModel;

namespace MerchandiseService.HttpClient
{
    public interface IMerchandiseServiceHttpClient
    {
        Task<List<Merchandise>> GetInformationAboutIssueMerchandise(CancellationToken token);
        Task<Merchandise> GetMerchandiseById(int merchId, CancellationToken token);
    }

    public class MerchandiseServiceHttpClient : IMerchandiseServiceHttpClient
    {
        private readonly System.Net.Http.HttpClient _httpClient;

        public MerchandiseServiceHttpClient(System.Net.Http.HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Merchandise>> GetInformationAboutIssueMerchandise(CancellationToken token)
        {
            using var response = await _httpClient.GetAsync("api/Merchandise", token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<List<Merchandise>>(body);
        }

        public async Task<Merchandise> GetMerchandiseById(int merchId, CancellationToken token)
        {
            using var response = await _httpClient.GetAsync("api/Merchandise/" + merchId, token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<Merchandise>(body);
        }
    }
}
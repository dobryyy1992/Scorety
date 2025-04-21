using System.Net.Http.Headers;
using System.Text.Json;
using Scorety.Server.Services.Interfaces;

namespace Scorety.Server.Services.Implementations
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<HttpClientService> _logger;
        private readonly JsonSerializerOptions _jsonOptions;

        public HttpClientService(IHttpClientFactory httpClientFactory, ILogger<HttpClientService> logger)
        {
            _httpClient = httpClientFactory.CreateClient();
            _logger = logger;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<T?> GetAsync<T>(string url, Dictionary<string, string>? headers = null)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                AddHeaders(request, headers);

                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(content, _jsonOptions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error making GET request to {Url}", url);
                throw;
            }
        }

        private void AddHeaders(HttpRequestMessage request, Dictionary<string, string>? headers)
        {
            if (headers == null) return;

            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }
        }
    }
} 
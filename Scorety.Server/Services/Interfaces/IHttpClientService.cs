using System.Net.Http.Headers;
using System.Text.Json;

namespace Scorety.Server.Services.Interfaces
{
    public interface IHttpClientService
    {
        Task<T?> GetAsync<T>(string url, Dictionary<string, string>? headers = null);
    }
} 
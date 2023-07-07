using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Aarim.Desafio.RickMorty.Helpers
{
    public static class HttpContentExtensions
    {

        private static readonly JsonSerializerOptions _defaultOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        public static async Task<T?> ReadAsAsync<T>(this HttpContent content, JsonSerializerOptions? options = null)
        where T : class
        {
            using (Stream contentStream = await content.ReadAsStreamAsync())
            return await JsonSerializer.DeserializeAsync<T>(contentStream, options ?? _defaultOptions);
        }

    }
}


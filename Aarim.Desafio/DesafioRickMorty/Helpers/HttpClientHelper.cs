using System;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Aarim.Desafio.RickMorty.Helpers
{
    internal class HttpClientHelper<T> : IDisposable
    where T : class
    {
        private HttpClient _client = new();


        public HttpClientHelper(string baseUri)
        {
            _client.BaseAddress = new Uri(baseUri);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<T> Get(string query)
        {
            T? content = null;
            using (var response = await _client.GetAsync(query))
            if (response.EnsureSuccessStatusCode().IsSuccessStatusCode)
                content = await response.Content.ReadAsAsync<T>();

            if (content is null)
                throw new BadHttpRequestException(
                    message: $"Null response content on convert GET: '{_client.BaseAddress}/{query}' to {typeof(T).Name} ",
                    statusCode: 500);
            return content;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                if (_client != null)
                {
                    _client.Dispose();
                }
        }
    }
}


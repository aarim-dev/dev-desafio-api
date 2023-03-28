using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace aarim.API.ExternalAPI
{
    public class ApiRequester
    {
        /// <summary>
        /// Executa a chamada da API
        /// </summary>
        /// <param name="absoluteURL">Url para consulta</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> RequestAPIAsync(string absoluteURL)
        {
            if (string.IsNullOrEmpty(absoluteURL))
                return null;
            else
            {
                if (!Uri.IsWellFormedUriString(absoluteURL, UriKind.Absolute))
                    return null;
            }

            using HttpClient client = new();

            return await client.GetAsync(absoluteURL);
        }

        public HttpResponseMessage RequestAPI(string absoluteURL) 
            => RequestAPIAsync(absoluteURL).GetAwaiter().GetResult();
    }
}

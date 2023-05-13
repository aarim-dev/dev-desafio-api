using System.Net;

namespace AC.Project.Resources.RickMorty.Exceptions
{
    public class RickMortyClientException : Exception
    {
        public HttpStatusCode statusCode { get; set; } 
        public RickMortyClientException(string message) : base(message) {
            statusCode = HttpStatusCode.InternalServerError;
        }

        public RickMortyClientException(string message, HttpStatusCode statusCode) : base(message) 
        {
            this.statusCode = statusCode;
        }

    }
}

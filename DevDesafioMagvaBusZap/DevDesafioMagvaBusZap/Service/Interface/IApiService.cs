using DevDesafioMagvaBusZap.Models;
using DevDesafioMagvaBusZap.Models.Results;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DevDesafioMagvaBusZap.Service.Interface
{
    /// <summary>
    /// Interface for API service to fetch character data of Ricky n' Morty.
    /// </summary>
    public interface IApiService
    {
        /// <summary>
        /// Asynchronously retrieves a list of characters with the specified parameters.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation, containing the result with a list of characters.</returns>
        public Task<Result<List<Character>>> GetDataByRequestedParameters();
    }
}

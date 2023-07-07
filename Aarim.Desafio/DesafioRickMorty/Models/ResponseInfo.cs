using System;
using System.ComponentModel;

namespace Aarim.Desafio.RickMorty.Models
{
    //https://rickandmortyapi.com/documentation/#info-and-pagination
    public class ResponseInfo
	{
        [Description("The length of the response.")]
        public int count { get; set; }

        [Description("The amount of pages.")]
        public int Pages { get; set; }

        [Description("(url) Link to the next page(if it exists)")]
        public string? Next { get; set; }

        [Description("(url) Link to the previous page(if it exists)")]
        public string? Previous { get; set; }
        
    }
}

